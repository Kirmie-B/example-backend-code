using Dapper;
using Garden.DataAccess.DataAccessObjects;
using Garden.Models;
using Moq;
using Moq.Dapper;
using System.Data;
using System.Data.Common;

namespace Garden.DataAccess.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="HardinessZoneDao"/> class.
/// </summary>
[TestFixture]
public class HardinessZoneDaoTests
{
    private HardinessZoneDao _hardinessZoneDao;

    private readonly Mock<IDapperWrapper> _dapperWrapperMock;
    private readonly Mock<IDbTransaction> _dbTransactionMock;
    private readonly Mock<DbConnection> _dbConnectionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public HardinessZoneDaoTests()
    {
        _dapperWrapperMock = new Mock<IDapperWrapper>(MockBehavior.Strict);
        _dbTransactionMock = new Mock<IDbTransaction>(MockBehavior.Strict);
        _dbConnectionMock = new Mock<DbConnection>(MockBehavior.Strict);

        _dbTransactionMock.Setup(mock => mock.Connection).Returns(_dbConnectionMock.Object);

        _hardinessZoneDao = new HardinessZoneDao(_dapperWrapperMock.Object);
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

    #region GetAllHardinessZones Tests

    /// <summary>
    /// Tests that <see cref="HardinessZoneDao.GetAllHardinessZones"/> returns all hardiness zones succesfully when multiple values are returned.
    /// </summary>
    [Test]
    public async Task GetAllHardinessZones_ReturnsAllHardinessZones_SuccessTest()
    {
        #region Setup

        var id1 = 4;
        var name1 = "Test Hardiness Zone";
        var description1 = "Test description";

        var hardinessZone1 = new HardinessZone
        {
            Id = id1,
            Name = name1,
            Description = description1,
        };


        var id2 = 7;
        var name2 = "Test Hardiness Zone 2";
        var description2 = "Test description 2";

        var hardinessZone2 = new HardinessZone
        {
            Id = id2,
            Name = name2,
            Description = description2,
        };

        var hardinessZones = new List<HardinessZone>{hardinessZone1, hardinessZone2};

        var sqlQuery = $@"
            SELECT 
                id AS {nameof(HardinessZone.Id)},
                name AS {nameof(HardinessZone.Name)},
                description AS {nameof(HardinessZone.Description)}
            FROM hardiness_zone";

        _dapperWrapperMock.Setup(mock => mock.QueryAsync<HardinessZone>(_dbConnectionMock.Object, sqlQuery)).ReturnsAsync(hardinessZones)
            .Verifiable(Times.Once);

        #endregion Setup

        var result = await _hardinessZoneDao.GetAllHardinessZones(_dbTransactionMock.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        var hardinessZone1Result = result.SingleOrDefault(hardinessZone => hardinessZone.Id == id1);
        Assert.That(hardinessZone1Result, Is.Not.Null, "The first HardinessZone was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(hardinessZone1Result.Id, Is.EqualTo(id1));
            Assert.That(hardinessZone1Result.Name, Is.EqualTo(name1));
            Assert.That(hardinessZone1Result.Description, Is.EqualTo(description1));
        });

        var hardinessZone2Result = result.SingleOrDefault(hardinessZone => hardinessZone.Id == id2);
        Assert.That(hardinessZone2Result, Is.Not.Null, "The second HardinessZone was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(hardinessZone2Result.Id, Is.EqualTo(id2));
            Assert.That(hardinessZone2Result.Name, Is.EqualTo(name2));
            Assert.That(hardinessZone2Result.Description, Is.EqualTo(description2));
        });
    }

    #endregion GetAllHardinessZones Tests
}
