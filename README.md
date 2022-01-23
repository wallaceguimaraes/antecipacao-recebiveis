# ROUTES EXAMPLES 

# Make the payment

# 1° make-payment
#
# 
# .../api/v2/payment/make-payment

# PASS JSON

# {
#	"creditCard": "5989182273827768",
#	"valueTotal": 4000,
#	"installmentsAmount": 5
# }


# Consult the transaction by ID

# 2° consult-transaction
#
# 
# .../api/v2/transfer/consult-transaction/7

#
# List all transactions
#
# 
# 3°../api/v2/transfer/list

# Request anticipation from the previous list of transactions
#
# 
# .../ap1/v2/advance-request/request
#
# PASS JSON
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
# 4° Consult available transactions
#
# ...api/v2/advance-request/consult-available-transactions
#
#
#
# 5° Start request fulfillment from a selected advance request
#
#  ...api/v2/advance-request/start-request-service
#
# PASS JSON
# 
# {
#	"advanceRequest": {
#							"advanceRequestId": 1,
#							"requestDate": "2022-01-22T10:23:54.7025959-03:00",
#							"startDateAnalysis": null,
#							"analysisEndDate": null,
#							"analysisResult": null,
#							"amountRequestedAdvance": 7889.10,
#							"anticipatedValue": null,
#							"requestedAdvances": null
#
#	}
# }
#
#
#
# 6° Approve Or Disapprove
# .../api/v2/advance-request/approve-disapprove
#
# PASS JSON
#
# {
#	"status": "disapprove",
#	"advanceRequestId": 1,
#	"transfers" : [
#		{
#		"transferId": 1,
#		"disapprovalDate": null,
#		"early": false,
#		"confirmationAcquirer": "APROVADA",
#		"grossTransferAmount": 7890.0,
#		"transferNetAmount": 7889.10,
#		"fixedRate": 0.90,
#		"installmentAmount": 2,
#		"cardDigits": "7768",
#		"portions": null
#		}
#	]
# }

# 7° Consult History By Situations
#
# .../api/v2/advance-request/consult-history
#
# PASS JSONs
#
# {
#	"situationId": 1
# } 
#  