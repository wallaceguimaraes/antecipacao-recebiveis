# ROUTES EXAMPLES 

# Make the payment

# 1° make-payment

# .../api/v2/payment/make-payment

# JSON

# {
#	"creditCard": "5989182273827768",
#	"valueTotal": 4000,
#	"installmentsAmount": 5
# }


# Consult the transaction by ID

# 2° consult-transaction

# .../api/v2/transfer/consult-transaction/7


# List all transactions

# 3°../api/v2/transfer/list

# Request anticipation from the previous list of transactions

# .../ap1/v2//advance-request/request


# {
#	"transfers": [
#		{
#			"transferId": 1,
#      		"datetransferMade": "2022-01-22T01:08:46.5250137",
#      		"approvalDate": "2022-01-22T01:08:46.5286585",
#      		"disapprovalDate": null,
#      		"early": false,
#      		"confirmationAcquirer": "APROVADA",
#      		"grossTransferAmount": 3300.00,
#      		"transferNetAmount": 3299.10,
#      		"fixedRate": 0.90,
#      		"installmentAmount": 2,
#      		"cardDigits": "7768",
#      		"portions": null
#		},
#		{
#			"transferId": 2,
#     		"datetransferMade": "2022-01-22T01:09:33.7866602",
#      		"approvalDate": "2022-01-22T01:09:33.786664",
#      		"disapprovalDate": null,
#      		"early": false,
#      		"confirmationAcquirer": "APROVADA",
#      		"grossTransferAmount": 7890.00,
#      		"transferNetAmount": 7889.10,
#      		"fixedRate": 0.90,
#      		"installmentAmount": 3,
#      		"cardDigits": "7768",
#			"portions": null
#		}
#	]
#		
# }		
#
#
#
#
#
#
#
#
#
#
#
#
#
