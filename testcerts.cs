public class TestCerts
{
    static void Main()
    {
        X509Certificate2 cert = null;
        X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        certStore.Open(OpenFlags.ReadOnly);

 

        foreach (X509Certificate2 certItem in certStore.Certificates)
        {
            Console.WriteLine("\r\nECerts Name:" + certItem.ToString() + ", Thumbprint: " + certItem.Thumbprint);
        }

 


        X509Certificate2Collection certs = certStore.Certificates.Find(X509FindType.FindBySubjectName, "jha.siteid.rsa.goldid.net", true);

 

        if (certs.Count == 1)
        {
            cert = (X509Certificate2)certs[0];

 

            if (!cert.HasPrivateKey)
            {
                Console.WriteLine("\r\n Private Key Not Found");
            }
            Console.WriteLine("\r\nExists! Certs Name is" + cert);
            Console.WriteLine("\r\nExists Certs Name and Location");
            Console.WriteLine("------ ----- -------------------------");
        }
        else if (certs.Count > 1)
        {
            Console.WriteLine("\r\n more than one certificate is found for the subject name");
        }
        else if (certs.Count < 1)
        {
            Console.WriteLine("\r\n Certificate could not be found");
        }

 

        Console.WriteLine("\r\n End of program!");

 

    }