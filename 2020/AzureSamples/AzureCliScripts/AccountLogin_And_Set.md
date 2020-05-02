# Login Related Commands

az login

az account list --output table

az account set -s "Your Subscription Name"

az account list --query "[].{name:name, subscriptionId:id, tenantId:tenantId}" --output table

az account set --subscription="${SUBSCRIPTION_ID}"

## For Terraform

az ad sp create-for-rbac --role="Contributor" --scopes="/subscriptions/${SUBSCRIPTION_ID}"

az ad sp list --query "[].{appDisplayName:appDisplayName, displayName:displayName, servicePrincipalNames:servicePrincipalNames}" --output table
