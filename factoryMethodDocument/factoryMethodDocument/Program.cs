﻿/* Programmierbeispiel factory method
 * Quelle: http://stg-tud.github.io/eise/WS14-EiSE-19-Factory_Method_and_Abstract_Factory_Design_Pattern.pdf
 * Angepasst durch: W. Eick am 6.7.16
 * */

using System;
using System.Collections.Generic;

namespace FactoryMethodDocument
{
    class Client
    {
        static void Main(string[] args)
        {
            TextApplication myApplication = new TextApplication();
            Document document = myApplication.createDocument();
            document.open();
            document.close();
            Console.ReadKey();
        }
    }
}

public abstract class Document
{
    public abstract void open();
    public abstract void close();
}
public class TextDocument : Document
{
    // Implementierung abstrakter Methoden
    public override void open()
    {
        Console.WriteLine("Oeffne Textdatei");
    }
    public override void close()
    {
        Console.WriteLine("Schliesse Textdatei");
    }
}

public abstract class Application
{
    private List<Document> docs = new List<Document>();
    public void newDocument()
    {
        Document doc = createDocument();
        // Framework managt die Dokumente
        docs.Add(doc);
        doc.open();
    }
    //...
    public abstract Document createDocument(); // Fabrikmethode
}
public class TextApplication : Application
{
    public override Document createDocument()
    {
        return new TextDocument();
    }
}
