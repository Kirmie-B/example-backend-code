using Dapper;
using Garden.DataAccess.DataAccessObjects;
using Garden.Models;
using Moq;
using Moq.Dapper;
using System.Data;
using System.Data.Common;

namespace Garden.DataAccess.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="SunlightNeedDao"/> class.
/// </summary>
[TestFixture]
public class SunlightNeedDaoTests
{
    private SunlightNeedDao _SunlightNeedDao;

    private readonly Mock<IDapperWrapper> _dapperWrapperMock;
    private readonly Mock<IDbTransaction> _dbTransactionMock;
    private readonly Mock<DbConnection> _dbConnectionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public SunlightNeedDaoTests()
    {
        _dapperWrapperMock = new Mock<IDapperWrapper>(MockBehavior.Strict);
        _dbTransactionMock = new Mock<IDbTransaction>(MockBehavior.Strict);
        _dbConnectionMock = new Mock<DbConnection>(MockBehavior.Strict);

        _dbTransactionMock.Setup(mock => mock.Connection).Returns(_dbConnectionMock.Object);

        _SunlightNeedDao = new SunlightNeedDao(_dapperWrapperMock.Object);
    }

    #region GetAllSunlightNeeds Tests

    /// <summary>
    /// Tests that <see cref="SunlightNeedDao.GetAllSunlightNeeds"/> returns all sunlight needs succesfully when multiple values are returned.
    /// </summary>
    [Test]
    public async Task GetAllSunlightNeeds_ReturnsAllSunlightNeeds_SuccessTest()
    {
        #region Setup

        var id1 = 4;
        var name1 = "Test Sunlight Need";
        var description1 = "Test description";

        var SunlightNeed1 = new SunlightNeed
        {
            Id = id1,
            Name = name1,
            Description = description1,
        };


        var id2 = 7;
        var name2 = "Test Sunlight Need2";
        var description2 = "Test description 2";

        var SunlightNeed2 = new SunlightNeed
        {
            Id = id2,
            Name = name2,
            Description = description2,
        };

        var sunlightNeeds = new List<SunlightNeed>{SunlightNeed2, SunlightNeed1};

        var sqlQuery = $@"
            SELECT 
                id AS {nameof(SunlightNeed.Id)},
                name AS {nameof(SunlightNeed.Name)},
                description AS {nameof(SunlightNeed.Description)}
            FROM sunlight_need";

        _dapperWrapperMock.Setup(mock => mock.QueryAsync<SunlightNeed>(_dbConnectionMock.Object, sqlQuery)).ReturnsAsync(sunlightNeeds)
            .Verifiable(Times.Once);

        #endregion Setup

        var result = await _SunlightNeedDao.GetAllSunlightNeeds(_dbTransactionMock.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        var SunlightNeed1Result = result.SingleOrDefault(SunlightNeed => SunlightNeed.Id == id1);
        Assert.That(SunlightNeed1Result, Is.Not.Null, "The first SunlightNeed was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(SunlightNeed1Result.Id, Is.EqualTo(id1));
            Assert.That(SunlightNeed1Result.Name, Is.EqualTo(name1));
            Assert.That(SunlightNeed1Result.Description, Is.EqualTo(description1));
        });

        var SunlightNeed2Result = result.SingleOrDefault(SunlightNeed => SunlightNeed.Id == id2);
        Assert.That(SunlightNeed2Result, Is.Not.Null, "The second SunlightNeed was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(SunlightNeed2Result.Id, Is.EqualTo(id2));
            Assert.That(SunlightNeed2Result.Name, Is.EqualTo(name2));
            Assert.That(SunlightNeed2Result.Description, Is.EqualTo(description2));
        });

        _dapperWrapperMock.VerifyAll();
    }

    #endregion GetAllSunlightNeeds Tests
}
