# Main Title

## Sub-Title

az account list --output table
az account set --subscription "Guid"

## Retrieve the Resource Groups

az group list --output table

## Retrieve the Resources with the Resource Group

az resource list --resource-group Your-GUID --resource-type Microsoft.Web/sites

Output
[
  {
    "id": "/subscriptions/Guid/resourceGroups/Your-GUID/providers/Microsoft.Web/sites/firstwordpress2009",
    "identity": null,
    "kind": "app",
    "location": "centralus",
    "managedBy": null,
    "name": "firstwordpress2009",
    "plan": null,
    "properties": null,
    "resourceGroup": "Your-GUID",
    "sku": null,
    "tags": null,
    "type": "Microsoft.Web/sites"
  }
]

## To Stop the WebSite

az webapp stop --id "/subscriptions/Guid/resourceGroups/Your-GUID/providers/Microsoft.Web/sites/firstwordpress2009"

## To Start the WebSite

az webapp start --id "/subscriptions/Guid/resourceGroups/Your-GUID/providers/Microsoft.Web/sites/firstwordpress2009"
