# Sudoku Validator

## Instructions

Étant donnée une grille de sudoku complète, écrire un programme qui valide si elle est correcte ou non.

Dans une grille de sudoku, chaque ligne, colonne et région ne doit contenir qu'une seule fois chaque chiffre de 1 à 9.

## Exemple

<style>
    .grid thead {
        display: none;
    }
    .grid tbody {
        border: solid white 2px;
    }
    .grid tr:nth-child(3n+1) {
        border-top: solid white 2px;
    }
    .grid tr td:nth-child(3n+1) { 
        border-left: solid white 2px;
    }

    .solution tr:nth-child(2) {
        background-color: palevioletred;
    }
    .solution tr td:nth-child(1) {
        background-color: palevioletred;
    }
    .solution tr:nth-child(-n + 3) td:nth-child(-n + 3) {
        background-color: palevioletred;
    }
    .solution tr:nth-child(2) td:nth-child(1) {
        font-weight: bold;
        text-decoration: underline;
        background-color: #d55a83;
    }
</style>

<div class="grid">

|   |   |   |   |   |   |   |   |   |
|---|---|---|---|---|---|---|---|---|
| 7 | 2 | 4 | 1 | 6 | 5 | 3 | 8 | 9 |
| 1 | 3 | 5 | 2 | 8 | 9 | 4 | 6 | 7 |
| 8 | 9 | 6 | 3 | 4 | 7 | 1 | 2 | 5 |
| 2 | 1 | 7 | 5 | 9 | 3 | 6 | 4 | 8 |
| 5 | 4 | 3 | 6 | 1 | 8 | 7 | 9 | 2 |
| 9 | 6 | 8 | 4 | 7 | 2 | 5 | 1 | 3 |
| 4 | 5 | 2 | 9 | 3 | 1 | 8 | 7 | 6 |
| 3 | 7 | 1 | 8 | 2 | 6 | 9 | 5 | 4 |
| 6 | 8 | 9 | 7 | 5 | 4 | 2 | 3 | 1 |

</div>

Dans cet exemple, le chiffre `1` ne se répète qu'une seule fois dans sa ligne, colonne et case
<div class="grid solution">

|   |   |   |   |   |   |   |   |   |
|---|---|---|---|---|---|---|---|---|
| 7 | 2 | 4 | 1 | 6 | 5 | 3 | 8 | 9 |
| 1 | 3 | 5 | 2 | 8 | 9 | 4 | 6 | 7 |
| 8 | 9 | 6 | 3 | 4 | 7 | 1 | 2 | 5 |
| 2 | 1 | 7 | 5 | 9 | 3 | 6 | 4 | 8 |
| 5 | 4 | 3 | 6 | 1 | 8 | 7 | 9 | 2 |
| 9 | 6 | 8 | 4 | 7 | 2 | 5 | 1 | 3 |
| 4 | 5 | 2 | 9 | 3 | 1 | 8 | 7 | 6 |
| 3 | 7 | 1 | 8 | 2 | 6 | 9 | 5 | 4 |
| 6 | 8 | 9 | 7 | 5 | 4 | 2 | 3 | 1 |

</div>
