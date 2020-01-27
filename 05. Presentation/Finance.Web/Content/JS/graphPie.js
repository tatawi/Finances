

//Pie - Dépenses année - Chargement données
function LoadGraphPieDepensesAnnee(graphId, annee, displayLegend) {

    var baseUrl = window.location+'Consolidation/GetGraphiqueDepensesPie/';
        var tab_Annees = 0;
        var tab_Logement = 0;
        var tab_Entreprise = 0;
        var tab_Alimentaire = 0;
        var tab_Voiture = 0;
        var tab_Transport = 0;
        var tab_Loisirs = 0;
        var tab_Voyage = 0;
        var tab_Cadeaux = 0;
        var tab_Vetements = 0;
        var tab_Sante = 0;
        var tab_Impots = 0;
        var tab_Frais = 0;
        var tab_Emprunt = 0;

        $.getJSON(baseUrl, {Annee: annee}, function (result) {
            $.each(result, function (index, itemData) {
                tab_Annees = itemData.Annee;
                tab_Logement = itemData.Logement;
                tab_Alimentaire = itemData.Alimentaire;
                tab_Voiture = itemData.Voiture;
                tab_Transport = itemData.Transport;
                tab_Loisirs = itemData.Loisirs;
                tab_Voyage = itemData.Voyage;
                tab_Cadeaux = itemData.Cadeaux;
                tab_Achats = itemData.Achats;
                tab_Vetements = itemData.Vetements;
                tab_Sante = itemData.Sante;
                tab_Impots = itemData.Impots;
                tab_Frais = itemData.Frais;
                tab_Emprunt = itemData.Emprunt;
            });
            if (displayLegend) {
                DisplayGraphPieDepensesAnneeLegend(graphId, annee, tab_Annees, tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt);
            }
            else {
                DisplayGraphPieDepensesAnnee(graphId, annee, tab_Annees, tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt);
            }
        });
    }

//Pie - Revenus année - Chargement données
function LoadGraphPieRevenusAnnee(graphId, annee, displayLegend) {
    var baseUrl = window.location +'Consolidation/GetGraphiqueRevenusPie/';

    var tab_Annees = 0;
    var tab_Salaire = 0;
    var tab_Entreprise = 0;
    var tab_Aides = 0;
    var tab_Interets = 0;
    var tab_Vente = 0;
    var tab_AirBnb = 0;
    var tab_Cadeaux = 0;

    $.getJSON(baseUrl, { Annee: annee }, function (result) {
        $.each(result, function (index, itemData) {
            tab_Annees = itemData.Annee;
            tab_Salaire = itemData.Salaire;
            tab_Entreprise = itemData.Entreprise;
            tab_Aides = itemData.Aides;
            tab_Interets = itemData.Interets;
            tab_Vente = itemData.Vente;
            tab_AirBnb = itemData.Airbnb;
            tab_Cadeaux = itemData.Cadeaux;
        });
        if (displayLegend) {
            DisplayGraphPieRevenusAnneeLegend(graphId, annee, tab_Annees, tab_Salaire, tab_Entreprise, tab_Aides, tab_Interets, tab_Vente, tab_AirBnb, tab_Cadeaux);
        }
        else {
            DisplayGraphPieRevenusAnnee(graphId, annee, tab_Annees, tab_Salaire, tab_Entreprise, tab_Aides, tab_Interets, tab_Vente, tab_AirBnb, tab_Cadeaux);
        }
    });
}


//------------------------------------------------------------------------------------------------------------------------
//Pie - Dépenses année - Affichage sans titre
function DisplayGraphPieDepensesAnnee(graphId, annee, tab_Annees, tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt) {
    var ctx = document.getElementById(graphId).getContext('2d');
    var chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [
                    tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt,
                ],
                backgroundColor: ['#9FA8DA', '#CE93D8', '#B0BEC5', '#616161', '#FFAB91', '#A5D6A7', '#B2EBF2', '#BCAAA4', '#AFB42B', '#FFF59D', '#EF9A9A', '#F8BBD0', '#E1BEE7',],
                label: 'Dataset 1'
            }],
            labels: [
                'Logement', 'Alimentaire', 'Voiture', 'Transport',
                'Loisirs', 'Voyage', 'Cadeaux', 'Achats',
                'Vétements', 'Santé', 'Impôts', 'Frais Bancaires',
                'Emprunt'
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 1,
            legend: {
                display: false,
                position: 'left'
            },

            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    });
}

//Pie - Dépenses année - Affichage sans titre
function DisplayGraphPieDepensesAnneeLegend(graphId, annee, tab_Annees, tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt) {
    var ctx = document.getElementById(graphId).getContext('2d');
    var chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [
                    tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt,
                ],
                backgroundColor: ['#9FA8DA', '#CE93D8', '#B0BEC5', '#616161', '#FFAB91', '#A5D6A7', '#B2EBF2', '#BCAAA4', '#AFB42B', '#FFF59D', '#EF9A9A', '#F8BBD0', '#E1BEE7',],
                label: 'Dataset 1'
            }],
            labels: [
                'Logement', 'Alimentaire', 'Voiture', 'Transport',
                'Loisirs', 'Voyage', 'Cadeaux', 'Achats',
                'Vétements', 'Santé', 'Impôts', 'Frais Bancaires',
                'Emprunt'
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 1,
            legend: {
                display: true,
                position: 'left'
            },


            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    });
}


//------------------------------------------------------------------------------------------------------------------------
//Pie - Revenus année - Affichage sans titre
function DisplayGraphPieRevenusAnnee(graphId, annee, tbAnnees, tab_Salaire, tab_Entreprise, tab_Aides, tab_Interets, tab_Vente, tab_AirBnb, tab_Cadeaux) {
    var ctx = document.getElementById(graphId).getContext('2d');
    var chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [
                    tab_Salaire,
                    tab_Entreprise,
                    tab_Aides,
                    tab_Interets,
                    tab_Vente,
                    tab_AirBnb,
                    tab_Cadeaux,
                ],
                backgroundColor: ['#81C784', '#AED581', '#A5D6A7', '#4DB6AC', '#C5E1A5', '#DCE775', '#80CBC4',],
                label: 'Dataset 1'
            }],
            labels: [
                'Salaire',
                'Entreprise',
                'Aides',
                'Intêrets',
                'Vente', 'Airbnb', 'Cadeaux'
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 1,
            legend: {
                display: false,
                position: 'left'
            },

            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    });


}

//Pie - Revenus année - Affichage sans titre
function DisplayGraphPieRevenusAnneeLegend(graphId, annee, tbAnnees, tab_Salaire, tab_Entreprise, tab_Aides, tab_Interets, tab_Vente, tab_AirBnb, tab_Cadeaux) {
    var ctx = document.getElementById(graphId).getContext('2d');
    var chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [
                    tab_Salaire,
                    tab_Entreprise,
                    tab_Aides,
                    tab_Interets,
                    tab_Vente,
                    tab_AirBnb,
                    tab_Cadeaux,
                ],
                backgroundColor: ['#81C784', '#AED581', '#A5D6A7', '#4DB6AC', '#C5E1A5', '#DCE775', '#80CBC4',],
                label: 'Dataset 1'
            }],
            labels: [
                'Salaire',
                'Entreprise',
                'Aides',
                'Intêrets',
                'Vente', 'Airbnb', 'Cadeaux'
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio:true,
            aspectRatio:1,
            legend: {
                display: true,
                position: 'left'
            },

            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    });


}




