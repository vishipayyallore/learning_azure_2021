# Service Principal Commands

az login

az account list --output table

az account set -s "Your Subscription Name"

## From inside the Azure Cloud Shell

az ad sp create-for-rbac -n ServicePrincipalName
