using System.Runtime.CompilerServices;

namespace csharp_biblioteca
{
    public class Utente
    {
        public string cognome { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public uint telefono { get; set; }

        public string nomeUtente { get { return nome + " " + cognome; } }

        public Utente(string cognome, string nome, string email, string password, uint telefono)
        {
            this.cognome = cognome;
            this.nome = nome;
            this.email = email;
            this.password = password;
            this.telefono = telefono;
        }

    }

    public class Autore
    {
        public string nomeAutore { get; set; }
        public string cognomeAutore { get; set; }

        public string nomeCompleto { get { return nomeAutore + " " + cognomeAutore; } }

        public Autore(string nome, string cognome)
        {
            this.nomeAutore = nome;
            this.cognomeAutore = cognome;
        }



    }
    public class Documento
    {
        public string id { get; set; }
        public string titolo { get; set; }
        public string settore { get; set; }
        public int scaffale { get; set; }

        public Autore autore { get; set; }

        public Documento(string id, string titolo, string settore, int scaffale, string nomeAutore, string cognomeAutore)
        {
            this.id = id;
            this.titolo = titolo;
            this.settore = settore;
            this.scaffale = scaffale;

            this.autore = new Autore(nomeAutore, cognomeAutore);


        }

    }

    public class Libro : Documento
    {
        public int numeroPagine { get; set; }

        //id, titolo,settore,scaffale,nome e congnome sono derivati da documento
        public Libro(string id, string titolo, string settore, int scaffale, string nome, string cognome, int numeroPagine) : base(id, titolo, settore, scaffale, nome, cognome)
        {
            this.numeroPagine = numeroPagine;

        }

    }
    public class Dvd : Documento
    {
        public int durata { get; set; }

        public Dvd(string id, string titolo, string settore, int scaffale, string nome, string cognome, int durata) : base(id, titolo, settore, scaffale, nome, cognome)
        {
            this.durata = durata;
        }
    }

    public class Prestito
    {
        public string id { get; set; }
        public string titoloLibro { get; set; }
        public DateTime dataInizio;
        public DateTime dataFine;
        public string nome { get; set; }
        public string cognome { get; set; }


        public Prestito(string id, string titoloLibro, DateTime dataInizio, DateTime dataFine, string nome, string cognome)
        {
            this.id = id;
            this.titoloLibro = titoloLibro;
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
            this.nome = nome;
            this.cognome = cognome;

        }
    }
    public class Biblioteca
    {
        private List<Documento> documenti;
        private List<Utente> utenti;
        private List<Prestito> prestiti;

        public Biblioteca()
        {
            this.documenti = new List<Documento>();
            this.utenti = new List<Utente>();
            this.prestiti = new List<Prestito>();
        }

        public void AggiungiDocumento(Documento id)
        {
            documenti.Add(id);
        }
        
        public void AggiungiUtente(Utente utente)
        {
            utenti.Add(utente);
        }

        public void AggiungiPrestito(Prestito prestito)
        {
            prestiti.Add(prestito);
        }

        //metodo x trovare dentro lista documento 
        public Documento CercaDocumento(string id)
        {
            foreach (Documento documento in documenti)
            {
                if (documento.id == id)
                return documento;
            }
            return null;
        }



        public Prestito CercaUtenteNeiPrestiti(string nome, string cognome)
        {
            foreach (Prestito prestito in prestiti)
            {
                if ((prestito.nome == nome) && (prestito.cognome == cognome))
                    return prestito;
            }
            return null;
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
        
            Biblioteca biblioteca = new Biblioteca();
 

            Utente utente1 = new Utente("rossi", "mario", "mariorossi@gmail.com", "mariopass", 3276512410);
            biblioteca.AggiungiUtente(utente1);

            Libro libro2 = new Libro("50055", "valle e monti", "letteratura", 16, "umberto", "eco", 587);
            Libro libro3 = new Libro("50057", "il rosa", "letteratura", 15, "umberto", "eco", 982);       
            Libro libro1 = new Libro("50059", "il nome della rosa", "letteratura", 19, "umberto", "eco", 1205);

            biblioteca.AggiungiDocumento(libro1);
            biblioteca.AggiungiDocumento(libro2);
            biblioteca.AggiungiDocumento(libro3);

            var libro = biblioteca.CercaDocumento("50057");

            
            Console.WriteLine(libro.titolo);



            DateTime dataInizio = DateTime.Today;
            DateTime dataFine = dataInizio.AddDays(10);
            Prestito prestito1 = new Prestito("02145", "harry potter e la camera dei segreti", dataInizio, dataFine, "luca", "rossi");
            Prestito prestito2 = new Prestito("021453", "harry potter e il calice di fuoco", dataInizio, dataFine, "luigi", "rossi");
            biblioteca.AggiungiPrestito(prestito1);
            biblioteca.AggiungiPrestito(prestito2);

            var prestito = biblioteca.CercaUtenteNeiPrestiti("luigi", "rossi");
            Console.WriteLine("prestito: " +prestito.titoloLibro);



        }
    }
}