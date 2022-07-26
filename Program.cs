using System;
using System.Collections;
using NotifyLib.Notify;

namespace NotifyEmail;
    public class Program
    {
        static void Main(string[] args)
        {
            Notify not = new Notify();
            ArrayList attachments = new ArrayList();
            try{
                Console.Write("Sender: ");
                string sender = Console.ReadLine();
                Console.Write("Password Sender: ");
                string passwordSender = Console.ReadLine();
                Console.Write("Recipient: ");
                string recipient = Console.ReadLine();
                Console.Write("Subject: ");
                string subject = Console.ReadLine();
                Console.Write("Message: ");
                string message = Console.ReadLine();
                Console.Write("Do you to add attachments with your body of email? (Y/N) ");
                char answer = char.Parse(Console.ReadLine().ToUpper());
                if(answer == 'Y')
                {
                    char stop = 'N';
                    do
                    {
                        Console.WriteLine("Type the path: example (C:\\...)");
                        string path = Console.ReadLine();
                        attachments.Add(path);
                        Console.WriteLine("Add again? (Y/N)");
                        stop = char.Parse(Console.ReadLine().ToUpper());
                    }while(stop == 'Y');
                }

                not.SendEmail(sender,passwordSender,recipient,subject,message, attachments);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }