# ARM Templates Related Commands 

az group deployment validate --resource-group rsg-use-armdeploydemo --template-file .\template.json --parameters .\parameters.json --verbose

az group deployment create --resource-group rsg-use-armdeploydemo --template-file .\template.json --parameters .\parameters.json --verbose
