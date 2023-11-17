// Titre : trouver les coupures en 100$, 50$, 20$, 10$, 5$, 2$, 1$, 0,25$, 0,10$ et 0,05$ d'un montant d'argent donné,
// arrondi aux 5 cents près, de façon à donner le moins d'espèces de monnaie que possible

// Déclarer les constantes
int[] COUPURES_EN_CENTS = new int[10] {10000, 5000, 2000, 1000, 500, 200, 100, 25, 10, 5};

// Déclarer les variables
int[] monnaie = new int[10];
string continuer = "";

// Tant que la variable resultat n'est pas égale à "non", on exécute le code qui suit
do
{
    // Exécuter le bloc de code qui suit, en cherchant pour des erreurs
    try
    {
        // Déclarer et initialiser la variable
        double montant_en_cents = 0;

        // Entrer la valeur du montant d'argent
        Console.WriteLine("Entrez le montant d’argent à décomposer en coupures, dans le format 0,00 :");

        // Définir la variable, et tronquer le montant total à une valeure entière après l'avoir transformé en cents
        montant_en_cents = double.Parse(Console.ReadLine()) * 100;

        // Trouver le montant arrondi aux 5 cents près
        double montant_a_decomposer = montant_en_cents - montant_en_cents % 5 + Math.Round((montant_en_cents % 5) / 5) * 5;

        // Afficher la ligne suivante
        Console.WriteLine("\nPour avoir le moins de billets et de pièces possible avec " + (montant_en_cents / 100).ToString("0.00") + "$, arrondi aux 5 cents près, il faut décomposer le montant total selon les coupures suivantes :");

        // Calculer les quantités de chaque coupure de monnaie, puis afficher chaque résultat
        for (int compteur_de_coupures = 0; compteur_de_coupures < COUPURES_EN_CENTS.Length; compteur_de_coupures++)
        {
            monnaie[compteur_de_coupures] = (int)((montant_a_decomposer - montant_a_decomposer % COUPURES_EN_CENTS[compteur_de_coupures]) / COUPURES_EN_CENTS[compteur_de_coupures]);
            montant_a_decomposer = montant_a_decomposer - monnaie[compteur_de_coupures] * COUPURES_EN_CENTS[compteur_de_coupures];
            Console.WriteLine(monnaie[compteur_de_coupures] + " * " + (COUPURES_EN_CENTS[compteur_de_coupures] / (double)100).ToString("0.00") + "$");
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

    // Si la variable continuer n'est pas vide, alors on prend le premier caractère et on le met en minuscule
    if (continuer != "")
    {
        continuer = continuer.Substring(0, 1).ToLower();
    }

    // Afficher le message
    Console.Write("\n");
} while (continuer != "n");