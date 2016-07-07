/* Programmierbeispiel factory method
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
            KoncreteApplication myApplication = new KoncreteApplication();
            Document document = myApplication.createDocument(ApplicationType.TEXT);
            document.open();
            document.close();

            document = myApplication.createDocument(ApplicationType.GRAPHIC);
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
public class GraphicDocument : Document
{
    // Implementierung abstrakter Methoden
    public override void open()
    {
        Console.WriteLine("Oeffne Graphikdatei");
    }
    public override void close()
    {
        Console.WriteLine("Schliesse Graphikdatei");
    }
}

public abstract class Application
{
    private List<Document> docs = new List<Document>();
    public void newDocument(ApplicationType applicationType)
    {
        Document doc = createDocument(applicationType);
        // Framework managt die Dokumente
        docs.Add(doc);
        doc.open();
    }
    //...
    public abstract Document createDocument(ApplicationType applicationType); // Fabrikmethode
}
public class KoncreteApplication : Application
{
    public override Document createDocument(ApplicationType applicationType)
    {
        switch (applicationType)
        {
            case ApplicationType.TEXT:
                return new TextDocument();
            case ApplicationType.GRAPHIC:
                return new GraphicDocument();
            default:
                return null;
        }
    }
}

//Aufzählungstyp (Integerkonstanten wg. Komfort)
public enum ApplicationType
{
    TEXT,
    GRAPHIC
}
