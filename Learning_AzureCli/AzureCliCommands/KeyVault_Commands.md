# Azure Key Vault Related Commands

## Login 

az login
az account list --output table
az account set -s "Your Subscription Name"

# Azure Key Vault 

az group create --name "resource-group-name" --location eastus
az keyvault create --name "simple-keyvalut" --resource-group "delete-me" --location eastus
az keyvault secret set --vault-name "simple-keyvalut" --name "ExamplePassword" --value "182723DJDJFDFD-3-40"
az keyvault secret show --name "ExamplePassword" --vault-name "simple-keyvalut"
az group delete --name delete-me
