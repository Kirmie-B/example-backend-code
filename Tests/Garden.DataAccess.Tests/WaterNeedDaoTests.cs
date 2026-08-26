using Dapper;
using Garden.DataAccess.DataAccessObjects;
using Garden.Models;
using Moq;
using Moq.Dapper;
using System.Data;
using System.Data.Common;

namespace Garden.DataAccess.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="WaterNeedDao"/> class.
/// </summary>
[TestFixture]
public class WaterNeedDaoTests
{
    private WaterNeedDao _waterNeedDao;

    private readonly Mock<IDapperWrapper> _dapperWrapperMock;
    private readonly Mock<IDbTransaction> _dbTransactionMock;
    private readonly Mock<DbConnection> _dbConnectionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public WaterNeedDaoTests()
    {
        _dapperWrapperMock = new Mock<IDapperWrapper>(MockBehavior.Strict);
        _dbTransactionMock = new Mock<IDbTransaction>(MockBehavior.Strict);
        _dbConnectionMock = new Mock<DbConnection>(MockBehavior.Strict);

        _dbTransactionMock.Setup(mock => mock.Connection).Returns(_dbConnectionMock.Object);

        _waterNeedDao = new WaterNeedDao(_dapperWrapperMock.Object);
    }

    #region GetAllWaterNeeds Tests

    /// <summary>
    /// Tests that <see cref="WaterNeedDao.GetAllWaterNeeds"/> returns all water needs succesfully when multiple values are returned.
    /// </summary>
    [Test]
    public async Task GetAllWaterNeeds_ReturnsAllWaterNeeds_SuccessTest()
    {
        #region Setup

        var id1 = 4;
        var name1 = "Test Water Need";
        var description1 = "Test description";

        var waterNeed1 = new WaterNeed
        {
            Id = id1,
            Name = name1,
            Description = description1,
        };


        var id2 = 7;
        var name2 = "Test Water Need 2";
        var description2 = "Test description 2";

        var waterNeed2 = new WaterNeed
        {
            Id = id2,
            Name = name2,
            Description = description2,
        };

        var waterNeeds = new List<WaterNeed>{waterNeed2, waterNeed1};

        var sqlQuery = $@"
            SELECT 
                id AS {nameof(WaterNeed.Id)},
                name AS {nameof(WaterNeed.Name)},
                description AS {nameof(WaterNeed.Description)}
            FROM water_need";

        _dapperWrapperMock.Setup(mock => mock.QueryAsync<WaterNeed>(_dbConnectionMock.Object, sqlQuery)).ReturnsAsync(waterNeeds)
            .Verifiable(Times.Once);

        #endregion Setup

        var result = await _waterNeedDao.GetAllWaterNeeds(_dbTransactionMock.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        var waterNeed1Result = result.SingleOrDefault(waterNeed => waterNeed.Id == id1);
        Assert.That(waterNeed1Result, Is.Not.Null, "The first WaterNeed was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(waterNeed1Result.Id, Is.EqualTo(id1));
            Assert.That(waterNeed1Result.Name, Is.EqualTo(name1));
            Assert.That(waterNeed1Result.Description, Is.EqualTo(description1));
        });

        var waterNeed2Result = result.SingleOrDefault(waterNeed => waterNeed.Id == id2);
        Assert.That(waterNeed2Result, Is.Not.Null, "The second WaterNeed was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(waterNeed2Result.Id, Is.EqualTo(id2));
            Assert.That(waterNeed2Result.Name, Is.EqualTo(name2));
            Assert.That(waterNeed2Result.Description, Is.EqualTo(description2));
        });

        _dapperWrapperMock.VerifyAll();
    }

    #endregion GetAllWaterNeeds Tests
}
