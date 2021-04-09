wget -q -O - https://dot.net/v1/dotnet-install.sh | bash -s -- --version 3.1.102
export PATH="~/.dotnet:$PATH"
echo "export PATH=~/.dotnet:\$PATH" >> ~/.bashrc
