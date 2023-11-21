Use SL_ProjectDB_1;

CREATE PROCEDURE AddProject
    @Title NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @Period NVARCHAR(MAX),
    @DateYear INT,
    @CountryId UNIQUEIDENTIFIER,
    @RequestDescription NVARCHAR(MAX),
    @RequestList NVARCHAR(MAX),
    @SolutionDescription NVARCHAR(MAX),
    @ResultFirstParagraph NVARCHAR(MAX),
    @ResultSecondParagraph NVARCHAR(MAX),
    @ResultThirdParagraph NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert Country if not exists
    IF NOT EXISTS (SELECT 1 FROM Country WHERE Id = @CountryId)
    BEGIN
        INSERT INTO Country (Id, Name, Code, CreatedDateTime)
        VALUES (@CountryId, 'Country Name', 'Country Code', GETDATE());
    END

    -- Insert Project
    INSERT INTO Project (Title, Description, Period, DateYear, CountryId, RequestDescription, RequestList, SolutionDescription, ResultFirstParagraph, ResultSecondParagraph, ResultThirdParagraph, CreatedDateTime)
    VALUES (@Title, @Description, @Period, @DateYear, @CountryId, @RequestDescription, @RequestList, @SolutionDescription, @ResultFirstParagraph, @ResultSecondParagraph, @ResultThirdParagraph, GETDATE());
END

SELECT OBJECT_DEFINITION(OBJECT_ID('AddProject')) AS 'ProcedureText';