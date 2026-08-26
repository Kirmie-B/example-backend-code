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

    private readonly Mock<IDbTransaction> _dbTransactionMock;
    private readonly Mock<DbConnection> _dbConnectionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public HardinessZoneDaoTests()
    {
        _dbTransactionMock = new Mock<IDbTransaction>();
        _dbConnectionMock = new Mock<DbConnection>();

        _dbTransactionMock.Setup(mock => mock.Connection).Returns(_dbConnectionMock.Object);

        _hardinessZoneDao = new HardinessZoneDao();
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

        // Need to setup the mock separately from the verification when using SetupDapperAsync or a null reference expception occurs.
        var mockSetup = _dbConnectionMock.SetupDapperAsync(mock => mock.QueryAsync<HardinessZone>(sqlQuery));
        mockSetup.ReturnsAsync(hardinessZones);
        mockSetup.Verifiable(Times.Once);

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

        // Must use Verify() instead of VerifyAll() or a null reference exception occurs from the use of SetupDapperAsync(...).
        _dbConnectionMock.Verify();
    }

    #endregion GetAllHardinessZones Tests
}
