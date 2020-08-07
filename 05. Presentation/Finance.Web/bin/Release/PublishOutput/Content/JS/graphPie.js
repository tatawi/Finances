

//Pie - Dépenses année - Chargement données
function LoadGraphPieDepensesAnnee(graphId, annee, displayLegend) {

    var baseUrl = window.location+'Consolidation/GetGraphiqueDepensesPie/';
    var Logement = 0;
    var Alimentaire = 0;
    var Voiture = 0;
    var Transport = 0;
    var Loisirs = 0;
    var Voyage = 0;
    var Cadeaux = 0;
    var Achats = 0;
    var Vetements = 0;
    var Sante = 0;
    var Impots = 0;
    var Frais = 0;
    var Emprunt = 0;
    var result;

        $.getJSON(baseUrl, {Annee: annee}, function (result) {
            $.each(result, function (index, itemData) {
                result = itemData;
                $.each(result.Logement, function () { Logement += parseFloat(this) || 0; });
                $.each(result.Alimentaire, function () { Alimentaire += parseFloat(this) || 0; });
                $.each(result.Voiture, function () { Voiture += parseFloat(this) || 0; });
                $.each(result.Transport, function () { Transport += parseFloat(this) || 0; });
                $.each(result.Loisirs, function () { Loisirs += parseFloat(this) || 0; });
                $.each(result.Voyage, function () { Voyage += parseFloat(this) || 0; });
                $.each(result.Cadeaux, function () { Cadeaux += parseFloat(this) || 0; });
                $.each(result.Achats, function () { Achats += parseFloat(this) || 0; });
                $.each(result.Vetements, function () { Vetements += parseFloat(this) || 0; });
                $.each(result.Sante, function () { Sante += parseFloat(this) || 0; });
                $.each(result.Impots, function () { Impots += parseFloat(this) || 0; });
                $.each(result.Frais, function () { Frais += parseFloat(this) || 0; });
                $.each(result.Emprunt, function () { Emprunt += parseFloat(this) || 0; });
            });
            if (displayLegend) {
                DisplayGraphPieDepensesAnneeLegend(graphId, Logement, Alimentaire, Voiture, Transport, Loisirs, Voyage, Cadeaux, Achats, Vetements, Sante, Impots, Frais, Emprunt);
            }
            else {
                DisplayGraphPieDepensesAnnee(graphId, Logement, Alimentaire, Voiture, Transport, Loisirs, Voyage, Cadeaux, Achats, Vetements, Sante, Impots, Frais, Emprunt);
            }
        });
    }

//Pie - Revenus année - Chargement données
function LoadGraphPieRevenusAnnee(graphId, annee, displayLegend) {
    var baseUrl = window.location +'Consolidation/GetGraphiqueRevenusPie/';
    var Salaire = 0;
    var Entreprise = 0;
    var Aides = 0;
    var Interets = 0;
    var Vente = 0;
    var Airbnb = 0;
    var Cadeaux = 0;
    var result;

    $.getJSON(baseUrl, { Annee: annee }, function (result) {
        $.each(result, function (index, itemData) {
            result = itemData;

            $.each(result.Salaire, function () { Salaire += parseFloat(this) || 0; });
            $.each(result.Entreprise, function () { Entreprise += parseFloat(this) || 0; });
            $.each(result.Aides, function () { Aides += parseFloat(this) || 0; });
            $.each(result.Interets, function () { Interets += parseFloat(this) || 0; });
            $.each(result.Vente, function () { Vente += parseFloat(this) || 0; });
            $.each(result.Airbnb, function () { Airbnb += parseFloat(this) || 0; });
            $.each(result.Cadeaux, function () { Cadeaux += parseFloat(this) || 0; });
        });
        if (displayLegend) {
            DisplayGraphPieRevenusAnneeLegend(graphId, Salaire, Entreprise, Aides, Interets, Vente, Airbnb, Cadeaux);
        }
        else {
            DisplayGraphPieRevenusAnnee(graphId, Salaire, Entreprise, Aides, Interets, Vente, Airbnb, Cadeaux);
        }
    });
}


//------------------------------------------------------------------------------------------------------------------------
//Pie - Dépenses année - Affichage sans titre
function DisplayGraphPieDepensesAnnee(graphId, tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt) {
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
function DisplayGraphPieDepensesAnneeLegend(graphId, tab_Logement, tab_Alimentaire, tab_Voiture, tab_Transport, tab_Loisirs, tab_Voyage, tab_Cadeaux, tab_Achats, tab_Vetements, tab_Sante, tab_Impots, tab_Frais, tab_Emprunt) {
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
function DisplayGraphPieRevenusAnnee(graphId, tab_Salaire, tab_Entreprise, tab_Aides, tab_Interets, tab_Vente, tab_AirBnb, tab_Cadeaux) {
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
function DisplayGraphPieRevenusAnneeLegend(graphId, tab_Salaire, tab_Entreprise, tab_Aides, tab_Interets, tab_Vente, tab_AirBnb, tab_Cadeaux) {
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




