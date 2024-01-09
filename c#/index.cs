using System;
using System.Linq;
using Xunit;

public class SudokuValidator
{
    public static bool ValidateGrid(int[][] grid)
    {
        return true; // Add your implementation here
    }
}

public class SudokuValidatorTests
{
    [Fact]
    public void ValidGrid_ShouldReturnTrue()
    {
        int[][] validGrid = new int[][]
        {
            new int[] {7, 2, 4, 1, 6, 5, 3, 8, 9},
            new int[] {1, 3, 5, 2, 8, 9, 4, 6, 7},
            new int[] {8, 9, 6, 3, 4, 7, 1, 2, 5},
            new int[] {2, 1, 7, 5, 9, 3, 6, 4, 8},
            new int[] {5, 4, 3, 6, 1, 8, 7, 9, 2},
            new int[] {9, 6, 8, 4, 7, 2, 5, 1, 3},
            new int[] {4, 5, 2, 9, 3, 1, 8, 7, 6},
            new int[] {3, 7, 1, 8, 2, 6, 9, 5, 4},
            new int[] {6, 8, 9, 7, 5, 4, 2, 3, 1}
        };

        Assert.True(SudokuValidator.ValidateGrid(validGrid));
    }

    [Fact]
    public void InvalidGrid_ShouldReturnFalse_ForNumberNotBetween1And9()
    {
        int[][] invalidGrid = DeepCopy(validGrid);
        invalidGrid[3][5] = 10;
        invalidGrid[6][4] = 0;
        Assert.False(SudokuValidator.ValidateGrid(invalidGrid));
    }

    [Fact]
    public void InvalidGrid_ShouldReturnFalse_ForDuplicateValueInLine()
    {
        int[][] invalidGrid = DeepCopy(validGrid);
        // invert 2 values within a region to create duplicates in lines
        invalidGrid[3][4] = validGrid[4][4];
        invalidGrid[4][4] = validGrid[3][4];
        // => no duplicate in column nor region
        Assert.False(SudokuValidator.ValidateGrid(invalidGrid));
    }

    [Fact]
    public void InvalidGrid_ShouldReturnFalse_ForDuplicateValueInColumn()
    {
        int[][] invalidGrid = DeepCopy(validGrid);
        // invert 2 values within a region to create duplicates in columns
        invalidGrid[3][4] = validGrid[3][5];
        invalidGrid[3][5] = validGrid[3][4];
        // => no duplicate in line nor region
        Assert.False(SudokuValidator.ValidateGrid(invalidGrid));
    }

    [Fact]
    public void InvalidGrid_ShouldReturnFalse_ForDuplicateValueInRegion()
    {
        int[][] invalidGrid = DeepCopy(validGrid);
        // invert 2 values to create duplicates in regions
        // in row 2, invert 3 and 6
        invalidGrid[2][2] = validGrid[2][3];
        invalidGrid[2][3] = validGrid[2][2];
        // in row 4, invert 6 and 3
        invalidGrid[4][2] = validGrid[4][3];
        invalidGrid[4][3] = validGrid[4][2];
        // => create duplicates in two regions, but none in column nor row
        Assert.False(SudokuValidator.ValidateGrid(invalidGrid));
    }

    private int[][] DeepCopy(int[][] source)
    {
        return source.Select(row => row.ToArray()).ToArray();
    }
}
