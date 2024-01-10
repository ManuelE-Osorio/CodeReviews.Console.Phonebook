namespace PhoneBookProgram;

public class ContactDtoWithSelection(Contact contact)
{
    public string? Selected { get; set; } = "[ ]";
    public string? ContactName { get; } = contact.ContactName;
    public string? Category { get; } = contact.Category;
}