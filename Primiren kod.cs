using System;
using System.Collections.Generic;

public class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }

    public Contact(string name, string phoneNumber, string email, string address, string password)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Password = password;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}, Address: {Address}";
    }
}

public class AddressBook
{
    private List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void ListContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\nNo contacts available.");
        }
        else
        {
            Console.WriteLine("\nContacts in Address Book:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }

    public void SearchContact(string name)
    {
        var foundContacts = contacts.FindAll(contact => contact.Name.ToLower().Contains(name.ToLower()));
        if (foundContacts.Count > 0)
        {
            Console.WriteLine("\nContact(s) found:");
            foreach (var contact in foundContacts)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("\nContact not found.");
        }
    }

    public bool DeleteContact(string name, string password)
    {
        var contactToDelete = contacts.Find(contact => contact.Name.ToLower().Contains(name.ToLower()));
        if (contactToDelete != null)
        {
            // Check if the password matches
            if (contactToDelete.Password == password)
            {
                contacts.Remove(contactToDelete);
                Console.WriteLine("\nContact deleted.");
                return true;
            }
            else
            {
                Console.WriteLine("\nIncorrect password. Access denied.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("\nContact not found.");
            return false;
        }
    }

    public bool EditContact(string name, string password)
    {
        var contactToEdit = contacts.Find(contact => contact.Name.ToLower().Contains(name.ToLower()));
        if (contactToEdit != null)
        {
            // Check if the password matches
            if (contactToEdit.Password == password)
            {
                Console.WriteLine("\nEditing Contact:");
                Console.WriteLine(contactToEdit);

                Console.Write("\nEnter new Phone Number (or press Enter to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) contactToEdit.PhoneNumber = phoneNumber;

                Console.Write("Enter new Email (or press Enter to keep current): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) contactToEdit.Email = email;

                Console.Write("Enter new Address (or press Enter to keep current): ");
                string address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address)) contactToEdit.Address = address;

                Console.WriteLine("\nContact updated:");
                Console.WriteLine(contactToEdit);
                return true;
            }
            else
            {
                Console.WriteLine("\nIncorrect password. Access denied.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("\nContact not found.");
            return false;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("\nAddress Book Menu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Edit Contact");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        Contact contact = new Contact(name, phoneNumber, email, address, password);
                        addressBook.AddContact(contact);
                        Console.WriteLine("\nContact added!");
                        break;

                    case 2:
                        addressBook.ListContacts();
                        break;

                    case 3:
                        Console.Write("\nEnter name to search: ");
                        string searchName = Console.ReadLine();
                        addressBook.SearchContact(searchName);
                        break;

                    case 4:
                        Console.Write("\nEnter the name of the contact to delete: ");
                        string deleteName = Console.ReadLine();
                        Console.Write("Enter password to delete the contact: ");
                        string deletePassword = Console.ReadLine();
                        addressBook.DeleteContact(deleteName, deletePassword);
                        break;

                    case 5:
                        Console.Write("\nEnter the name of the contact to edit: ");
                        string editName = Console.ReadLine();
                        Console.Write("Enter password to edit the contact: ");
                        string editPassword = Console.ReadLine();
                        addressBook.EditContact(editName, editPassword);
                        break;

                    case 6:
                        Console.WriteLine("\nGoodbye!");
                        return;

                    default:
                        Console.WriteLine("\nInvalid option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a valid number.");
            }
        }
    }
}

