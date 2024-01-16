namespace PhoneBookProgram;

public class UI
{
    public static void WelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Phone Book App!\n");
        Thread.Sleep(2000);
    }

    public static void DisplayContacts(List<ContactDto> contacts, int selection, int prevSelection, int currentPage) 
    {
        Console.Clear();
        int endRange;
        int totalPages = (contacts.Count+DataController.PageSize-1)/DataController.PageSize;

        if(contacts.Count > 0)
        {
            contacts[prevSelection].Selected = "[ ]";
            contacts[selection].Selected = "[x]";
        }
        if( currentPage*DataController.PageSize+10 > contacts.Count)
            endRange = contacts.Count - currentPage*DataController.PageSize;
        else
            endRange = DataController.PageSize;

        TableUI.PrintTable(contacts.GetRange(currentPage*DataController.PageSize, endRange));
        Console.WriteLine($"Page No {currentPage+1} of {totalPages}\n"+
            "User the arrows to select a contact\n"+
            "Press enter to check the details of the selected contact\n"+
            "Press I to create a new contact\n"+
            "Press M to modify the selected contact\n"+
            "Press D to delete the selected contact\n"+
            "Press F to filter by first letter\n"+
            "Press C to filter by category\n"+
            "Press Q to clear the search\n"+
            "Press P to import data to the app\n"+
            "Press Backspace/Esc to exit the application\n");
    }

    public static void DisplayContactData(List<PhoneNumberDto> phonesDto, List<EmailDto> emailsDto, 
        int selection, int prevSelection, string? contactName) 
    {
        Console.Clear();
        if(emailsDto.Count+phonesDto.Count  > 0)
        {
            if(prevSelection < phonesDto.Count) 
                phonesDto[prevSelection].Selected = "[ ]";
            else
                emailsDto[prevSelection - phonesDto.Count].Selected = "[ ]";
            if(selection < phonesDto.Count)
                phonesDto[selection].Selected = "[X]";
            else
                emailsDto[selection - phonesDto.Count].Selected = "[X]";
        }
        
        TableUI.PrintTable(phonesDto, contactName);
        TableUI.PrintTable(emailsDto, contactName);
        Console.WriteLine("User the arrows to select a phone number/email\n"+
            "Press enter to send an SMS/email to the selection\n"+ 
            "Press P/E to create a new phone/email to the selected contact\n"+
            "Press M to modify your selection\n"+
            "Press D to delete your selection\n"+
            "Press Backspace/Esc to return\n");
    }

    public static void DisplayConfirmationPromt(string objectName)
    {
        Console.Clear();
        Console.WriteLine($"Do you want to delete the selected {objectName}? [y/N]");
    }

    public static void DisplayInsert(string objectToInsert, string? errorMessage)
    {
        Console.Clear();
        if(errorMessage != null)
            Console.WriteLine($"Error: {errorMessage}");
        Console.WriteLine($"Please write the new {objectToInsert} or enter \"0\" to cancel.");

        switch(objectToInsert)
        {
            case("contact name"):
                Console.WriteLine($"A maximum of {PhoneBookContext.ContactNameLenght}"+
                    " characters are permited for the contact name");
                break;
            case("phone number"):
                Console.WriteLine($"The phone number need to contain the country code" +
                    " followed by the local number ie: +1 2315553331");
                break;
            case("email"):
                Console.WriteLine("The email has to contain the local name, followed by the "+
                    "@ symbol and the domain name ie: test@csharpacademy.com");
                break;
        }

    }

    public static void DisplayCategoryInsert(string objectToInsert, string? errorMessage)
    {
        Console.Clear();
        if(errorMessage != null)
            Console.WriteLine($"Error: {errorMessage}");
        Console.WriteLine($"Please write the new {objectToInsert} within {PhoneBookContext.ContactCategoryLenght} "+
            "or press enter to leave empty.");
    }

    public static void FilterByFirstLetter()
    {
        Console.Clear();
        Console.WriteLine("Write the first letter to filter the contacts\n");
    }

    public static void FilterByCategory()
    {
        Console.Clear();
        Console.WriteLine("Write the category name to filter the contacts\n");
    }

    public static void ExitMessage(string? errorMessage)
    {
        Console.Clear();
        if(errorMessage != null)
            Console.WriteLine("Error: " + errorMessage);

        Console.WriteLine("Thank you for using the Phone Book App!\n");
        Thread.Sleep(2000);
    }

    public static void ConfigureAppSettings(string? item)
    {
        Console.Clear();
        Console.WriteLine($"Please configure your appsettings.json file. The user {item} is invalid.");
    }

    public static void DisplayEmailSubject(string? errorMessage)
    {
        Console.Clear();
        if(errorMessage != null)
            Console.WriteLine("Error: " + errorMessage);
        Console.WriteLine("Please enter the email subject:");
    }

    public static void DisplayEmail(string? emailFrom, string? emailTo, string emailSubject, string? errorMessage)
    {
        Console.Clear();
        Console.WriteLine($"From: {emailFrom}");
        Console.WriteLine($"To: {emailTo}");
        Console.WriteLine($"Subject: {emailSubject}\n");
        if(errorMessage != null)
            Console.WriteLine("Error: " + errorMessage);
        Console.WriteLine($"Please write the email body, within {DataController.EmailBodySize}"+
            " characters, and press CRTL+S to send it"+
            " or CRTL+BackSpace to cancel:\n");
    }

    public static void DisplaySms(string? smsFrom, string? smsTo, string? errorMessage)
    {
        Console.Clear();
        Console.WriteLine($"From: {smsFrom}");
        Console.WriteLine($"To: {smsTo}");
        if(errorMessage != null)
            Console.WriteLine("Error: " + errorMessage);
        Console.WriteLine($"Please write the sms body, within {DataController.SMSBodySize}"+
            " characters, and press CRTL+S to send it"+
            " or CRTL+BackSpace to cancel:\n");
    }

    public static void DisplaySendEmail()
    {
        Console.Clear();
        Console.WriteLine("Sending email");
        Thread.Sleep(2000);
        Console.WriteLine("Email sent succesfully");
        Thread.Sleep(2000);
    }

    public static void DisplaySendSms()
    {
        Console.Clear();
        Console.WriteLine("Sending SMS");
        Thread.Sleep(2000);
        Console.WriteLine("SMS sent succesfully");
        Thread.Sleep(2000);
    }
}
