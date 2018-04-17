# Solutions
Few crossover solutions few hacker earth solutions

For reference of getbytes

https://msdn.microsoft.com/en-us/library/87z0hy49(v=vs.100).aspx

 public void ReadBlob()
        {
            SqlConnection pubsConn = new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=pubs;");

            SqlCommand logoCMD = new SqlCommand("SELECT contents FROM pub_info", pubsConn);

            FileStream fs;                          
            BinaryWriter bw;                        

            int bufferSize = 100;  
            ///outbyte you will pass to decompress method                 
            byte[] outbyte = new byte[bufferSize];

            long retval;                            
            long startIndex = 0;                  

                      

            // Open the connection and read data into the DataReader.
            pubsConn.Open();
            SqlDataReader myReader = logoCMD.ExecuteReader(CommandBehavior.SequentialAccess);
            while (myReader.Read())
            {
              

                // Create a file to hold the output.
                fs = new FileStream("blob.xml", FileMode.OpenOrCreate, FileAccess.Write);
                bw = new BinaryWriter(fs);

                // Reset the starting byte for the new BLOB.
                startIndex = 0;

                // Read the bytes into outbyte[] and retain the number of bytes returned.
                retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize);

                // Continue reading and writing while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    bw.Write(outbyte);
                    bw.Flush();

                    // Reposition the start index to the end of the last buffer and fill the buffer.
                    startIndex += bufferSize;
                    retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
                }

                // Write the remaining buffer.
                bw.Write(outbyte, 0, (int)retval - 1);
                bw.Flush();

               
            }
            ///Here call decompress and pass outbyte 
            ///Decompress(outbyte)

        }
