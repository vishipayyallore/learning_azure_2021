RGName="rg-practice-dev-001"
LocationName="EastUS"
BaseName="vmmay2021"
VmName="ubuntu$(echo $BaseName)" 
username="demouser"
ImageName="UbuntuLTS" 

ssh-keygen -t rsa -b 2048
cat ~/.ssh/id_rsa.pub

az group create --name $RGName --location $LocationName

az group list --output table

az vm create --resource-group $RGName --name $VmName --image $ImageName \
    --admin-username $username --authentication-type ssh --ssh-key-value ~/.ssh/id_rsa.pub

publicIp=$(az vm show --resource-group $RGName --name $VmName \
    --show-details --query publicIps --output tsv)

echo $publicIp

az vm open-port --resource-group $RGName --name $VmName --port 80

ssh -i ~/.ssh/id_rsa demouser@$publicIp

##### From within the Ubuntu VM

##### DEMO 1
sudo apt update && sudo apt install -y lamp-server^
logout

##### DEMO 2
sudo apt-get -y update
sudo apt-get -y install nginx
logout

##### View the site.
http://$publicIp"