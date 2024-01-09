const validateGrid = require('./index')

const validGrid = [
    [7, 2, 4,   1, 6, 5,   3, 8, 9],
    [1, 3, 5,   2, 8, 9,   4, 6, 7],
    [8, 9, 6,   3, 4, 7,   1, 2, 5],

    [2, 1, 7,   5, 9, 3,   6, 4, 8],
    [5, 4, 3,   6, 1, 8,   7, 9, 2],
    [9, 6, 8,   4, 7, 2,   5, 1, 3],

    [4, 5, 2,   9, 3, 1,   8, 7, 6],
    [3, 7, 1,   8, 2, 6,   9, 5, 4],
    [6, 8, 9,   7, 5, 4,   2, 3, 1],
]

describe('Sudoku Validator', () => {
    describe('Valid grid', () => {
        test('should return true for a valid grid', () => {
            expect(validateGrid(validGrid)).toBe(true)
        })
    })
    describe('Invalid grid', () => {
        test('should return false for a number not between 1 and 9 (both included)', () => {
            const invalidGrid = structuredClone(validGrid)
            invalidGrid[3][5] = 10
            invalidGrid[6][4] = 0
            expect(validateGrid(invalidGrid)).toBe(false)
        })
        test('should return false for a duplicate value in a line', () => {
            const invalidGrid = structuredClone(validGrid)
            // invert 2 values within a region to create duplicates in lines
            invalidGrid[3][4] = validGrid[4][4]
            invalidGrid[4][4] = validGrid[3][4]
            // => no duplicate in column nor region
            expect(validateGrid(invalidGrid)).toBe(false)
        })
        test('should return false for a duplicate value in a row', () => {
            const invalidGrid = structuredClone(validGrid)
            // invert 2 values within a region to create duplicates in columns
            invalidGrid[3][4] = validGrid[3][5]
            invalidGrid[3][5] = validGrid[3][4]
            // => no duplicate in line nor region
            expect(validateGrid(invalidGrid)).toBe(false)
        })
        test('should return false for a duplicate value in a region', () => {
            const invalidGrid = structuredClone(validGrid)
            // invert 2 values to create duplicates in regions
            // in row 2, invert 3 and 6
            invalidGrid[2][2] = validGrid[2][3]
            invalidGrid[2][3] = validGrid[2][2]
            // in row 4, invert 6 and 3
            invalidGrid[4][2] = validGrid[4][3]
            invalidGrid[4][3] = validGrid[4][2]
            // => create duplicates in two regions, but none in column nor row
            expect(validateGrid(invalidGrid)).toBe(false)
        })
    })
})
