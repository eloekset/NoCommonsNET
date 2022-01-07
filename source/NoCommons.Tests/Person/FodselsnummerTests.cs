using Xunit;
using NoCommons.Person;

namespace NoCommons.Tests.Person
{
        public class FodselsnummerTest {

        private const string VALID_FODSELSNUMMER = "01010123476";

        private const string VALID_D_FODSELSNUMMER = "41010123476";

        private Fodselsnummer sut;

        public FodselsnummerTest() {
	        sut = new Fodselsnummer(VALID_FODSELSNUMMER);
        }

        [Fact]
        public void testGetDateAndMonth() {
	        Assert.Equal("0101", sut.GetDateAndMonth());
        }

        [Fact]
        public void testGetDayInMonth() {
	        Assert.Equal("01", sut.GetDayInMonth());
	        sut = new Fodselsnummer(VALID_D_FODSELSNUMMER);
	        Assert.Equal("01", sut.GetDayInMonth());
        }

        [Fact]
        public void testGetMonth() {
	        Assert.Equal("01", sut.GetMonth());
        }

        [Fact]
        public void testGetDateAndMonthDNumber() {
	        sut = new Fodselsnummer(VALID_D_FODSELSNUMMER);
	        Assert.Equal("0101", sut.GetDateAndMonth());
        }

        [Fact]
        public void testGetCentury() {
	        sut = new Fodselsnummer("01016666609");
	        Assert.Equal("19", sut.GetCentury());

	        sut = new Fodselsnummer("01016633301");
	        Assert.Equal("19", sut.GetCentury());

	        sut = new Fodselsnummer("01019196697");
	        Assert.Equal("19", sut.GetCentury());

	        sut = new Fodselsnummer("01013366671");
	        Assert.Equal("20", sut.GetCentury());

            // DNumber...
            sut = new Fodselsnummer("41015850001");
            Assert.Equal("18", sut.GetCentury());

            sut = new Fodselsnummer("41019950001");
            Assert.Equal("18", sut.GetCentury());

            sut = new Fodselsnummer("41010006609");
	        Assert.Equal("19", sut.GetCentury());

            sut = new Fodselsnummer("01013906609");
            Assert.Equal("19", sut.GetCentury());

            sut = new Fodselsnummer("41014063301");
	        Assert.Equal("19", sut.GetCentury());

	        sut = new Fodselsnummer("41019996697");
	        Assert.Equal("19", sut.GetCentury());

	        sut = new Fodselsnummer("41013366671");
	        Assert.Equal("20", sut.GetCentury());

            sut = new Fodselsnummer("41014061033");
            Assert.Equal("19", sut.GetCentury());

            sut = new Fodselsnummer("41014065640");
            Assert.Equal("19", sut.GetCentury());

            sut = new Fodselsnummer("41014075603");
            Assert.Equal("19", sut.GetCentury());

            sut = new Fodselsnummer("41010021827");
            Assert.Equal("20", sut.GetCentury());

            sut = new Fodselsnummer("41010025091");
            Assert.Equal("20", sut.GetCentury());

            sut = new Fodselsnummer("41010034422");
            Assert.Equal("20", sut.GetCentury());
        }

        [Fact]
        public void testGet2DigitBirthYear() {
	        Assert.Equal("01", sut.Get2DigitBirthYear());
        }

        [Fact]
        public void testGetBirthYear() {
	        Assert.Equal("2001", sut.GetBirthYear());
	        sut = new Fodselsnummer(VALID_D_FODSELSNUMMER);
	        Assert.Equal("2001", sut.GetBirthYear());
        }

        [Fact]
        public void testGetDateOfBirth() {
	        Assert.Equal("010101", sut.GetDateOfBirth());
        }

        [Fact]
        public void testGetDateOfBirthDNumber() {
	        sut = new Fodselsnummer(VALID_D_FODSELSNUMMER);
	        Assert.Equal("010101", sut.GetDateOfBirth());
        }

        [Fact]
        public void testGetPersonnummer() {
	        Assert.Equal("23476", sut.GetPersonnummer());
        }

        [Fact]
        public void testGetIndividnummer() {
	        Assert.Equal("234", sut.GetIndividnummer());
        }

        [Fact]
        public void testGetGenderDigit() {
	        Assert.Equal(4, sut.GetGenderDigit());
        }

        [Fact]
        public void testGetChecksumDigits() {
	        Assert.Equal(7, sut.GetChecksumDigit1());
	        Assert.Equal(6, sut.GetChecksumDigit2());
        }

        [Fact]
        public void testIsMale() {
	        Assert.False(sut.IsMale());
        }

        [Fact]
        public void testIsMaleDNumber() {
	        sut = new Fodselsnummer(VALID_D_FODSELSNUMMER);
	        Assert.False(sut.IsMale());
        }

        [Fact]
        public void testIsFemale() {
	        Assert.True(sut.IsFemale());
        }

        [Fact]
        public void testIsFemaleDNumber() {
	        sut = new Fodselsnummer(VALID_D_FODSELSNUMMER);
	        Assert.True(sut.IsFemale());
        }

        [Fact]
        public void testIsDNumber() {
	        Assert.False(Fodselsnummer.IsDNumber("01010101006"));
	        Assert.False(Fodselsnummer.IsDNumber("80000000000"));
	        Assert.True(Fodselsnummer.IsDNumber("47086303651"));

            /* Rules valid from Nov 16th 2021: https://skatteetaten.github.io/folkeregisteret-api-dokumentasjon/sporsmal-og-svar/
             * Born 1940:
                41014061033
                41014065640
                41014075603
             */
            Assert.True(Fodselsnummer.IsDNumber("41014061033"));
            Assert.True(Fodselsnummer.IsDNumber("41014065640"));
            Assert.True(Fodselsnummer.IsDNumber("41014075603"));

            /* Rules valid from Nov 16th 2021: https://skatteetaten.github.io/folkeregisteret-api-dokumentasjon/sporsmal-og-svar/
             * Born 2000:
                41010021827
                41010025091
                41010034422
             */
            Assert.True(Fodselsnummer.IsDNumber("41010021827"));
            Assert.True(Fodselsnummer.IsDNumber("41010025091"));
            Assert.True(Fodselsnummer.IsDNumber("41010034422"));
        }

        [Fact]
        public void testParseDNumber() {
	        Assert.Equal("07086303651", Fodselsnummer.ParseDNumber("47086303651"));
        }
    }
}