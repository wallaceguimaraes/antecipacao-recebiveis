using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Models.ResultModel;
using api.Models.EntityModel.Queries;
using Microsoft.EntityFrameworkCore;
using api.Models.ViewModels;
using api.Models.EntityModel;


namespace api.Models.ServiceModel
{
    public class TransferService : ITransfer
    {
        private readonly DataContext _context;
        private readonly IPortion _portionService;

        public TransferService(DataContext context, IPortion portionService)
        {
            _context = context;
            _portionService = portionService;
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var transfers = await _context.Transfers
                                    .OrderById()
                                    .ToListAsync();

                if (transfers == null) return null;

                return new TransferListJson(transfers);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> SaveTransfer(PaymentModel vModel, string status)
        {
            Transfer transfer = new Transfer();
            string lastDigits = vModel.CreditCard.Substring(12, 4);
            transfer.CardDigits = lastDigits;
            transfer.GrossTransferAmount = vModel.ValueTotal;
            transfer.InstallmentAmount = vModel.InstallmentsAmount;

            if (status == "RECUSADA")
            {
                transfer.ConfirmationAcquirer = status;
                transfer.DisapprovalDate = DateTime.Now;
                transfer.Early = null;
                transfer.TransferNetAmount = vModel.ValueTotal;
            }
            else
            {
                transfer.ConfirmationAcquirer = status;
                transfer.ApprovalDate = DateTime.Now;
                transfer.Early = null;
                transfer.TransferNetAmount = (transfer.GrossTransferAmount - transfer.FixedRate);
            }

            try
            {
                _context.Add(transfer);

                await _context.SaveChangesAsync();

                if (status == "APROVADA")
                {
                    await _portionService.SavePortion(transfer);
                }

                return new TransferJson(transfer);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IActionResult> ConsultTransaction(int id)
        {
            try
            {
                var transfer = _context.Transfers.WhereId(id);

                if (transfer == null) return null;

                return new TransferListJson(transfer);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> DisapproveTransaction(int transferId)
        {
            //Pesquisar transacao
            Transfer transfer = _context.Transfers.WhereId(transferId).FirstOrDefault();

            transfer.Early = "N";

            try
            {
                _context.Update(transfer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            var transferJson = _context.Transfers.WhereId(transferId);

            return new TransferJson(transfer);

        }


        public async Task<IActionResult> ApproveTransaction(int transferId)
        {
            Transfer transfer = _context.Transfers.WhereId(transferId).FirstOrDefault();

            transfer.Early = "S";

            try
            {
                _context.Update(transfer);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            var transferJson = _context.Transfers.WhereId(transferId);

            return new TransferJson(transfer);

            //
        }

    }
}