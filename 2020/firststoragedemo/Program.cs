using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace firststoragedemo
{
    class Program
    {
        private static IConfiguration _config;

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddUserSecrets("62799a27-409a-4c9b-82d7-0d33627868f9")
                            .Build();

            for (int iCtr = 0; iCtr <= 99999; iCtr++)
            {
                Console.WriteLine($"{DateTime.UtcNow}");
            }

            if (!CloudStorageAccount.TryParse(_config["StorageAccountConnectionString"], out CloudStorageAccount storageAccount))
            {
                Console.WriteLine("Unable to parse connection string");
                return;
            }

            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference("photoblobs");
            bool created = await blobContainer.CreateIfNotExistsAsync();

            Console.WriteLine(created ? "Created the Blob container" : "Blob container already exists.");

            // Create a local object to represent our blob. No network call.
            string blobName = "userPhoto";
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(blobName);

            // This transfers data in the file to the blob on the service.
            string fileName = "./Images/first.png";
            await blob.UploadFromFileAsync(fileName);

            Console.WriteLine("Hello World!");

        }
    }
}
