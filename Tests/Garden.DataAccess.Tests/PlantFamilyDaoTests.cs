using Dapper;
using Garden.DataAccess.DataAccessObjects;
using Garden.Models;
using Moq;
using Moq.Dapper;
using System.Data;
using System.Data.Common;

namespace Garden.DataAccess.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="PlantFamilyDao"/> class.
/// </summary>
[TestFixture]
public class PlantFamilyDaoTests
{
    private PlantFamilyDao _plantFamilyDao;

    private readonly Mock<IDapperWrapper> _dapperWrapperMock;
    private readonly Mock<IDbTransaction> _dbTransactionMock;
    private readonly Mock<DbConnection> _dbConnectionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public PlantFamilyDaoTests()
    {
        _dbTransactionMock = new Mock<IDbTransaction>(MockBehavior.Strict);
        _dbConnectionMock = new Mock<DbConnection>(MockBehavior.Strict);
        _dapperWrapperMock = new Mock<IDapperWrapper>(MockBehavior.Strict);

        _dbTransactionMock.Setup(mock => mock.Connection).Returns(_dbConnectionMock.Object);

        _plantFamilyDao = new PlantFamilyDao(_dapperWrapperMock.Object);
    }

    /// <summary>
    /// Function that is run after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _dapperWrapperMock.VerifyAll();
        _dbTransactionMock.VerifyAll();
        _dbConnectionMock.VerifyAll();        
    }

    #region GetAllPlantFamilies Tests

    /// <summary>
    /// Tests that <see cref="PlantFamilyDao.GetAllPlantFamilies"/> returns all plant families succesfully when multiple values are returned.
    /// </summary>
    [Test]
    public async Task GetAllPlantFamilies_ReturnsAllPlantFamilies_SuccessTest()
    {
        #region Setup

        var id1 = 4;
        var name1 = "Test Plant Family";
        var description1 = "Test description";

        var plantFamily1 = new PlantFamily
        {
            Id = id1,
            Name = name1,
            Description = description1,
        };


        var id2 = 7;
        var name2 = "Test Plant Family 2";
        var description2 = "Test description 2";

        var plantFamily2 = new PlantFamily
        {
            Id = id2,
            Name = name2,
            Description = description2,
        };

        var plantFamilies = new List<PlantFamily>{plantFamily1, plantFamily2};

        var sqlQuery = $@"
            SELECT 
                id AS {nameof(PlantFamily.Id)},
                name AS {nameof(PlantFamily.Name)},
                description AS {nameof(PlantFamily.Description)}
            FROM plant_family";

        _dapperWrapperMock.Setup(mock => mock.QueryAsync<PlantFamily>(_dbConnectionMock.Object, sqlQuery)).ReturnsAsync(plantFamilies)
            .Verifiable(Times.Once);

        #endregion Setup

        var result = await _plantFamilyDao.GetAllPlantFamilies(_dbTransactionMock.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        var plantFamily1Result = result.SingleOrDefault(plantFamily => plantFamily.Id == id1);
        Assert.That(plantFamily1Result, Is.Not.Null, "The first PlantFamily was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(plantFamily1Result.Id, Is.EqualTo(id1));
            Assert.That(plantFamily1Result.Name, Is.EqualTo(name1));
            Assert.That(plantFamily1Result.Description, Is.EqualTo(description1));
        });

        var plantFamily2Result = result.SingleOrDefault(plantFamily => plantFamily.Id == id2);
        Assert.That(plantFamily2Result, Is.Not.Null, "The second PlantFamily was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(plantFamily2Result.Id, Is.EqualTo(id2));
            Assert.That(plantFamily2Result.Name, Is.EqualTo(name2));
            Assert.That(plantFamily2Result.Description, Is.EqualTo(description2));
        });
    }

    #endregion GetAllPlantFamilies Tests
}
