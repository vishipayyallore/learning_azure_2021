# Main Title

## Sub-Title

az account list --output table
az account set --subscription "Guid"

## Retrieve the Resource Groups

az group list --output table

## Retrieve the Resources with the Resource Group

az resource list --resource-group Learn-Guid --resource-type Microsoft.Web/sites

Output


## To Stop the WebSite

az webapp stop --id "/subscriptions/Guid/resourceGroups/Learn-Guid/providers/Microsoft.Web/sites/firstwordpress2009"

## To Start the WebSite

az webapp start --id "/subscriptions/Guid/resourceGroups/Learn-Guid/providers/Microsoft.Web/sites/firstwordpress2009"
