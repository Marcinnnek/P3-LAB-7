using System;
using System.Collections.Generic;

// Simple business object. A PartId is used to identify the
// type of part but the part name can change.
public class Vault : IComparable<Vault>
{
    public string VaultNme { get; set; }

    public int PartId { get; set; }

    public override string ToString() => 
        $"ID: {PartId}   Name: {VaultNme}";



 

    // Default comparer for Part type.
    // A null value means that this object is greater.
    public int CompareTo(Vault comparePart) =>
        comparePart == null ? 1 : PartId.CompareTo(comparePart.PartId);




    // Should also override == and != operators.
}

public class Example
{
    public static void Main()
    {
        // Create a list of parts.
        var parts = new List<Vault>
        {
            // Add parts to the list.
            new Vault { VaultNme = "regular seat", PartId = 1434 },
            new Vault { VaultNme = "crank arm", PartId = 1234 },
            new Vault { VaultNme = "shift lever", PartId = 1634 },
            // Name intentionally left null.
            new Vault { PartId = 1334 },
            new Vault { VaultNme = "banana seat", PartId = 1444 },
            new Vault { VaultNme = "cassette", PartId = 1534 }
        };
        
        // Write out the parts in the list. This will call the overridden
        // ToString method in the Part class.
        Console.WriteLine("\nBefore sort:");
        parts.ForEach(Console.WriteLine);

        // Call Sort on the list. This will use the
        // default comparer, which is the Compare method
        // implemented on Part.
        parts.Sort();

        Console.WriteLine("\nAfter sort by part number:");
        parts.ForEach(Console.WriteLine);

        // This shows calling the Sort(Comparison<T> comparison) overload using
        // a lambda expression as the Comparison<T> delegate.
        // This method treats null as the lesser of two values.
        parts.Sort((Vault x, Vault y) => 
            x.VaultNme == null && y.VaultNme == null ? 0: x.VaultNme == null? -1: y.VaultNme == null? 1: x.VaultNme.CompareTo(y.VaultNme));

        
        Console.WriteLine("\nAfter sort by name:");
        parts.ForEach(Console.WriteLine);

        /*

            Before sort:
        ID: 1434   Name: regular seat
        ID: 1234   Name: crank arm
        ID: 1634   Name: shift lever
        ID: 1334   Name:
        ID: 1444   Name: banana seat
        ID: 1534   Name: cassette

        After sort by part number:
        ID: 1234   Name: crank arm
        ID: 1334   Name:
        ID: 1434   Name: regular seat
        ID: 1444   Name: banana seat
        ID: 1534   Name: cassette
        ID: 1634   Name: shift lever

        After sort by name:
        ID: 1334   Name:
        ID: 1444   Name: banana seat
        ID: 1534   Name: cassette
        ID: 1234   Name: crank arm
        ID: 1434   Name: regular seat
        ID: 1634   Name: shift lever

         */
    }
}