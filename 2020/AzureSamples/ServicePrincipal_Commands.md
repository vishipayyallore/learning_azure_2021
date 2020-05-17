# Service Principal Commands

az login

az account list --output table

az account set -s "Your Subscription Name"

## From inside the Azure Cloud Shell

az ad sp create-for-rbac -n ServicePrincipalName

az ad sp list --display-name azure-cli-2020-05-03-16-02-26
az ad sp delete --id http://azure-cli-2020-05-03-16-02-26

