// Titre : trouver les coupures en 100$, 50$, 20$, 10$, 5$, 2$, 1$, 0,25$, 0,10$ et 0,05$ d'un montant d'argent donné,
// arrondi aux 5 cents près, de façon à donner le moins d'espèces de monnaie que possible

// Déclarer les constantes
double[] VALEUR = new double[10] {100, 50, 20, 10, 5, 2, 1, 0.25, 0.10, 0.05};

// Déclarer les variables
double[] monnaie = new double[10];
string continuer = "";

// Tant que la variable resultat n'est pas égale à "non", on exécute le code qui suit
do
{
    // Exécuter le bloc de code qui suit, en cherchant pour des erreurs
    try
    {
        // Déclarer et initialiser la variable
        double montant_total = 0;

        // Entrer la valeur du montant d'argent
        Console.WriteLine("Entrez le montant d’argent à décomposer en coupures, dans le format 0,00 :");

        // Définir la variable
        montant_total = double.Parse(Console.ReadLine());

        // Tronquer le montant total à une valeure entière après l'avoir transformé en cents
        double montant_en_cents = Math.Truncate(montant_total * 100);

        // Trouver le montant arrondi aux 5 cents près
        double montant_a_decomposer = montant_en_cents - montant_en_cents % 5 + Math.Round((montant_en_cents % 5) / 5) * 5;

        // Afficher la ligne suivante
        Console.WriteLine("\nPour avoir le moins de billets et de pièces possible avec " + montant_total.ToString("0.00") + "$, arrondi aux 5 cents près, il faut décomposer le montant total selon les coupures suivantes :");

        // Calculer les quantités de chaque coupure de monnaie, puis afficher chaque résultat
        for (int compteur = 0; compteur < VALEUR.Length; compteur++)
        {
            monnaie[compteur] = (montant_a_decomposer - montant_a_decomposer % (VALEUR[compteur] * 100)) / (VALEUR[compteur] * 100);
            montant_a_decomposer = montant_a_decomposer - monnaie[compteur] * (VALEUR[compteur] * 100);
            Console.WriteLine(monnaie[compteur] + " * " + VALEUR[compteur].ToString("0.00") + "$");
        }
    }

    // S'il y a une erreur dans le bloc de code précédent, afficher ce message
    catch (FormatException)
    {
        Console.WriteLine("Cette entrée n'est pas valide.");
    }

    // S'il y a une erreur dans le bloc de code précédent, afficher ce message
    catch (System.OverflowException)
    {
        Console.WriteLine("Cette entrée est trop large. Entrez un nombre dont la valeur absolue est plus petite que celle que vous venez d'entrer.");
    }

    // Afficher le message
    Console.WriteLine("\nVoulez-vous continuer? Tapez \"n\" (pour non), puis appuyez sur la touche Entrée pour terminer le programme.");

    // Lire la réponse
    continuer = Console.ReadLine();

    // Si la variable continuer est non vide, alors on prend le premier caractère et on le met en minuscule
    if (continuer != "") continuer = continuer.Substring(0, 1).ToLower();

    // Afficher le message
    Console.Write("\n");
} while (continuer != "n");