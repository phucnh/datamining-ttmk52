
USE [AIDT]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CourseGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_Get_List

AS


				
				SELECT
					[CourseGroupId],
					[Name],
					[Note]
				FROM
					[dbo].[CourseGroup]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CourseGroup table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [CourseGroupId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([CourseGroupId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [CourseGroupId]'
				SET @SQL = @SQL + ' FROM [dbo].[CourseGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[CourseGroupId], O.[Name], O.[Note]
				FROM
				    [dbo].[CourseGroup] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[CourseGroupId] = PageIndex.[CourseGroupId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CourseGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CourseGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_Insert
(

	@CourseGroupId int   ,

	@Name nvarchar (50)  ,

	@Note nvarchar (1024)  
)
AS


				
				INSERT INTO [dbo].[CourseGroup]
					(
					[CourseGroupId]
					,[Name]
					,[Note]
					)
				VALUES
					(
					@CourseGroupId
					,@Name
					,@Note
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CourseGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_Update
(

	@CourseGroupId int   ,

	@OriginalCourseGroupId int   ,

	@Name nvarchar (50)  ,

	@Note nvarchar (1024)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CourseGroup]
				SET
					[CourseGroupId] = @CourseGroupId
					,[Name] = @Name
					,[Note] = @Note
				WHERE
[CourseGroupId] = @OriginalCourseGroupId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CourseGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_Delete
(

	@CourseGroupId int   
)
AS


				DELETE FROM [dbo].[CourseGroup] WITH (ROWLOCK) 
				WHERE
					[CourseGroupId] = @CourseGroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_GetByCourseGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_GetByCourseGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_GetByCourseGroupId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CourseGroup table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_GetByCourseGroupId
(

	@CourseGroupId int   
)
AS


				SELECT
					[CourseGroupId],
					[Name],
					[Note]
				FROM
					[dbo].[CourseGroup]
				WHERE
					[CourseGroupId] = @CourseGroupId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseGroup_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseGroup_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseGroup_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CourseGroup table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseGroup_Find
(

	@SearchUsingOR bit   = null ,

	@CourseGroupId int   = null ,

	@Name nvarchar (50)  = null ,

	@Note nvarchar (1024)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CourseGroupId]
	, [Name]
	, [Note]
    FROM
	[dbo].[CourseGroup]
    WHERE 
	 ([CourseGroupId] = @CourseGroupId OR @CourseGroupId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CourseGroupId]
	, [Name]
	, [Note]
    FROM
	[dbo].[CourseGroup]
    WHERE 
	 ([CourseGroupId] = @CourseGroupId AND @CourseGroupId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Note] = @Note AND @Note is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the OccupationType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_Get_List

AS


				
				SELECT
					[OccupationTypeId],
					[OccupationName],
					[Note]
				FROM
					[dbo].[OccupationType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the OccupationType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [OccupationTypeId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([OccupationTypeId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [OccupationTypeId]'
				SET @SQL = @SQL + ' FROM [dbo].[OccupationType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[OccupationTypeId], O.[OccupationName], O.[Note]
				FROM
				    [dbo].[OccupationType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[OccupationTypeId] = PageIndex.[OccupationTypeId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[OccupationType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the OccupationType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_Insert
(

	@OccupationTypeId int   ,

	@OccupationName nvarchar (50)  ,

	@Note nvarchar (1024)  
)
AS


				
				INSERT INTO [dbo].[OccupationType]
					(
					[OccupationTypeId]
					,[OccupationName]
					,[Note]
					)
				VALUES
					(
					@OccupationTypeId
					,@OccupationName
					,@Note
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the OccupationType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_Update
(

	@OccupationTypeId int   ,

	@OriginalOccupationTypeId int   ,

	@OccupationName nvarchar (50)  ,

	@Note nvarchar (1024)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[OccupationType]
				SET
					[OccupationTypeId] = @OccupationTypeId
					,[OccupationName] = @OccupationName
					,[Note] = @Note
				WHERE
[OccupationTypeId] = @OriginalOccupationTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the OccupationType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_Delete
(

	@OccupationTypeId int   
)
AS


				DELETE FROM [dbo].[OccupationType] WITH (ROWLOCK) 
				WHERE
					[OccupationTypeId] = @OccupationTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_GetByOccupationTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_GetByOccupationTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_GetByOccupationTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the OccupationType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_GetByOccupationTypeId
(

	@OccupationTypeId int   
)
AS


				SELECT
					[OccupationTypeId],
					[OccupationName],
					[Note]
				FROM
					[dbo].[OccupationType]
				WHERE
					[OccupationTypeId] = @OccupationTypeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OccupationType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OccupationType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OccupationType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the OccupationType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OccupationType_Find
(

	@SearchUsingOR bit   = null ,

	@OccupationTypeId int   = null ,

	@OccupationName nvarchar (50)  = null ,

	@Note nvarchar (1024)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OccupationTypeId]
	, [OccupationName]
	, [Note]
    FROM
	[dbo].[OccupationType]
    WHERE 
	 ([OccupationTypeId] = @OccupationTypeId OR @OccupationTypeId IS NULL)
	AND ([OccupationName] = @OccupationName OR @OccupationName IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OccupationTypeId]
	, [OccupationName]
	, [Note]
    FROM
	[dbo].[OccupationType]
    WHERE 
	 ([OccupationTypeId] = @OccupationTypeId AND @OccupationTypeId is not null)
	OR ([OccupationName] = @OccupationName AND @OccupationName is not null)
	OR ([Note] = @Note AND @Note is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CustomerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_Get_List

AS


				
				SELECT
					[CustomerId],
					[Name],
					[Birthday],
					[OccupationTypeId]
				FROM
					[dbo].[CustomerDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CustomerDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [CustomerId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([CustomerId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [CustomerId]'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[CustomerId], O.[Name], O.[Birthday], O.[OccupationTypeId]
				FROM
				    [dbo].[CustomerDetails] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[CustomerId] = PageIndex.[CustomerId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CustomerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_Insert
(

	@CustomerId int   ,

	@Name nvarchar (50)  ,

	@Birthday nvarchar (50)  ,

	@OccupationTypeId int   
)
AS


				
				INSERT INTO [dbo].[CustomerDetails]
					(
					[CustomerId]
					,[Name]
					,[Birthday]
					,[OccupationTypeId]
					)
				VALUES
					(
					@CustomerId
					,@Name
					,@Birthday
					,@OccupationTypeId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CustomerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_Update
(

	@CustomerId int   ,

	@OriginalCustomerId int   ,

	@Name nvarchar (50)  ,

	@Birthday nvarchar (50)  ,

	@OccupationTypeId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CustomerDetails]
				SET
					[CustomerId] = @CustomerId
					,[Name] = @Name
					,[Birthday] = @Birthday
					,[OccupationTypeId] = @OccupationTypeId
				WHERE
[CustomerId] = @OriginalCustomerId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CustomerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_Delete
(

	@CustomerId int   
)
AS


				DELETE FROM [dbo].[CustomerDetails] WITH (ROWLOCK) 
				WHERE
					[CustomerId] = @CustomerId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_GetByOccupationTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_GetByOccupationTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_GetByOccupationTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_GetByOccupationTypeId
(

	@OccupationTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CustomerId],
					[Name],
					[Birthday],
					[OccupationTypeId]
				FROM
					[dbo].[CustomerDetails]
				WHERE
					[OccupationTypeId] = @OccupationTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_GetByCustomerId
(

	@CustomerId int   
)
AS


				SELECT
					[CustomerId],
					[Name],
					[Birthday],
					[OccupationTypeId]
				FROM
					[dbo].[CustomerDetails]
				WHERE
					[CustomerId] = @CustomerId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CustomerDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDetails_Find
(

	@SearchUsingOR bit   = null ,

	@CustomerId int   = null ,

	@Name nvarchar (50)  = null ,

	@Birthday nvarchar (50)  = null ,

	@OccupationTypeId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CustomerId]
	, [Name]
	, [Birthday]
	, [OccupationTypeId]
    FROM
	[dbo].[CustomerDetails]
    WHERE 
	 ([CustomerId] = @CustomerId OR @CustomerId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Birthday] = @Birthday OR @Birthday IS NULL)
	AND ([OccupationTypeId] = @OccupationTypeId OR @OccupationTypeId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CustomerId]
	, [Name]
	, [Birthday]
	, [OccupationTypeId]
    FROM
	[dbo].[CustomerDetails]
    WHERE 
	 ([CustomerId] = @CustomerId AND @CustomerId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Birthday] = @Birthday AND @Birthday is not null)
	OR ([OccupationTypeId] = @OccupationTypeId AND @OccupationTypeId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CourseCertificate table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_Get_List

AS


				
				SELECT
					[CertificateId],
					[CertificateName]
				FROM
					[dbo].[CourseCertificate]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CourseCertificate table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [CertificateId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([CertificateId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [CertificateId]'
				SET @SQL = @SQL + ' FROM [dbo].[CourseCertificate]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[CertificateId], O.[CertificateName]
				FROM
				    [dbo].[CourseCertificate] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[CertificateId] = PageIndex.[CertificateId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CourseCertificate]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CourseCertificate table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_Insert
(

	@CertificateId int   ,

	@CertificateName nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[CourseCertificate]
					(
					[CertificateId]
					,[CertificateName]
					)
				VALUES
					(
					@CertificateId
					,@CertificateName
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CourseCertificate table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_Update
(

	@CertificateId int   ,

	@OriginalCertificateId int   ,

	@CertificateName nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CourseCertificate]
				SET
					[CertificateId] = @CertificateId
					,[CertificateName] = @CertificateName
				WHERE
[CertificateId] = @OriginalCertificateId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CourseCertificate table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_Delete
(

	@CertificateId int   
)
AS


				DELETE FROM [dbo].[CourseCertificate] WITH (ROWLOCK) 
				WHERE
					[CertificateId] = @CertificateId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_GetByCertificateId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_GetByCertificateId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_GetByCertificateId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CourseCertificate table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_GetByCertificateId
(

	@CertificateId int   
)
AS


				SELECT
					[CertificateId],
					[CertificateName]
				FROM
					[dbo].[CourseCertificate]
				WHERE
					[CertificateId] = @CertificateId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseCertificate_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseCertificate_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseCertificate_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CourseCertificate table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseCertificate_Find
(

	@SearchUsingOR bit   = null ,

	@CertificateId int   = null ,

	@CertificateName nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CertificateId]
	, [CertificateName]
    FROM
	[dbo].[CourseCertificate]
    WHERE 
	 ([CertificateId] = @CertificateId OR @CertificateId IS NULL)
	AND ([CertificateName] = @CertificateName OR @CertificateName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CertificateId]
	, [CertificateName]
    FROM
	[dbo].[CourseCertificate]
    WHERE 
	 ([CertificateId] = @CertificateId AND @CertificateId is not null)
	OR ([CertificateName] = @CertificateName AND @CertificateName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CourseDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_Get_List

AS


				
				SELECT
					[CourseId],
					[CourseName],
					[CourseCertificate],
					[CourseFee],
					[CourseGroup]
				FROM
					[dbo].[CourseDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CourseDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [CourseId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([CourseId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [CourseId]'
				SET @SQL = @SQL + ' FROM [dbo].[CourseDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[CourseId], O.[CourseName], O.[CourseCertificate], O.[CourseFee], O.[CourseGroup]
				FROM
				    [dbo].[CourseDetails] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[CourseId] = PageIndex.[CourseId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CourseDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CourseDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_Insert
(

	@CourseId int   ,

	@CourseName nvarchar (50)  ,

	@CourseCertificate int   ,

	@CourseFee float   ,

	@CourseGroup int   
)
AS


				
				INSERT INTO [dbo].[CourseDetails]
					(
					[CourseId]
					,[CourseName]
					,[CourseCertificate]
					,[CourseFee]
					,[CourseGroup]
					)
				VALUES
					(
					@CourseId
					,@CourseName
					,@CourseCertificate
					,@CourseFee
					,@CourseGroup
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CourseDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_Update
(

	@CourseId int   ,

	@OriginalCourseId int   ,

	@CourseName nvarchar (50)  ,

	@CourseCertificate int   ,

	@CourseFee float   ,

	@CourseGroup int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CourseDetails]
				SET
					[CourseId] = @CourseId
					,[CourseName] = @CourseName
					,[CourseCertificate] = @CourseCertificate
					,[CourseFee] = @CourseFee
					,[CourseGroup] = @CourseGroup
				WHERE
[CourseId] = @OriginalCourseId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CourseDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_Delete
(

	@CourseId int   
)
AS


				DELETE FROM [dbo].[CourseDetails] WITH (ROWLOCK) 
				WHERE
					[CourseId] = @CourseId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_GetByCourseCertificate procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_GetByCourseCertificate') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_GetByCourseCertificate
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CourseDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_GetByCourseCertificate
(

	@CourseCertificate int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CourseId],
					[CourseName],
					[CourseCertificate],
					[CourseFee],
					[CourseGroup]
				FROM
					[dbo].[CourseDetails]
				WHERE
					[CourseCertificate] = @CourseCertificate
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_GetByCourseGroup procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_GetByCourseGroup') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_GetByCourseGroup
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CourseDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_GetByCourseGroup
(

	@CourseGroup int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CourseId],
					[CourseName],
					[CourseCertificate],
					[CourseFee],
					[CourseGroup]
				FROM
					[dbo].[CourseDetails]
				WHERE
					[CourseGroup] = @CourseGroup
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_GetByCourseId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_GetByCourseId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_GetByCourseId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CourseDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_GetByCourseId
(

	@CourseId int   
)
AS


				SELECT
					[CourseId],
					[CourseName],
					[CourseCertificate],
					[CourseFee],
					[CourseGroup]
				FROM
					[dbo].[CourseDetails]
				WHERE
					[CourseId] = @CourseId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CourseDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CourseDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CourseDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CourseDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CourseDetails_Find
(

	@SearchUsingOR bit   = null ,

	@CourseId int   = null ,

	@CourseName nvarchar (50)  = null ,

	@CourseCertificate int   = null ,

	@CourseFee float   = null ,

	@CourseGroup int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CourseId]
	, [CourseName]
	, [CourseCertificate]
	, [CourseFee]
	, [CourseGroup]
    FROM
	[dbo].[CourseDetails]
    WHERE 
	 ([CourseId] = @CourseId OR @CourseId IS NULL)
	AND ([CourseName] = @CourseName OR @CourseName IS NULL)
	AND ([CourseCertificate] = @CourseCertificate OR @CourseCertificate IS NULL)
	AND ([CourseFee] = @CourseFee OR @CourseFee IS NULL)
	AND ([CourseGroup] = @CourseGroup OR @CourseGroup IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CourseId]
	, [CourseName]
	, [CourseCertificate]
	, [CourseFee]
	, [CourseGroup]
    FROM
	[dbo].[CourseDetails]
    WHERE 
	 ([CourseId] = @CourseId AND @CourseId is not null)
	OR ([CourseName] = @CourseName AND @CourseName is not null)
	OR ([CourseCertificate] = @CourseCertificate AND @CourseCertificate is not null)
	OR ([CourseFee] = @CourseFee AND @CourseFee is not null)
	OR ([CourseGroup] = @CourseGroup AND @CourseGroup is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the TeacherDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_Get_List

AS


				
				SELECT
					[TeacherId],
					[TeacherName],
					[TeacherCertificate],
					[Note]
				FROM
					[dbo].[TeacherDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the TeacherDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [TeacherId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([TeacherId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [TeacherId]'
				SET @SQL = @SQL + ' FROM [dbo].[TeacherDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[TeacherId], O.[TeacherName], O.[TeacherCertificate], O.[Note]
				FROM
				    [dbo].[TeacherDetails] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[TeacherId] = PageIndex.[TeacherId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[TeacherDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the TeacherDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_Insert
(

	@TeacherId int   ,

	@TeacherName nvarchar (50)  ,

	@TeacherCertificate int   ,

	@Note nvarchar (1024)  
)
AS


				
				INSERT INTO [dbo].[TeacherDetails]
					(
					[TeacherId]
					,[TeacherName]
					,[TeacherCertificate]
					,[Note]
					)
				VALUES
					(
					@TeacherId
					,@TeacherName
					,@TeacherCertificate
					,@Note
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the TeacherDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_Update
(

	@TeacherId int   ,

	@OriginalTeacherId int   ,

	@TeacherName nvarchar (50)  ,

	@TeacherCertificate int   ,

	@Note nvarchar (1024)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[TeacherDetails]
				SET
					[TeacherId] = @TeacherId
					,[TeacherName] = @TeacherName
					,[TeacherCertificate] = @TeacherCertificate
					,[Note] = @Note
				WHERE
[TeacherId] = @OriginalTeacherId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the TeacherDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_Delete
(

	@TeacherId int   
)
AS


				DELETE FROM [dbo].[TeacherDetails] WITH (ROWLOCK) 
				WHERE
					[TeacherId] = @TeacherId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_GetByTeacherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_GetByTeacherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_GetByTeacherId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the TeacherDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_GetByTeacherId
(

	@TeacherId int   
)
AS


				SELECT
					[TeacherId],
					[TeacherName],
					[TeacherCertificate],
					[Note]
				FROM
					[dbo].[TeacherDetails]
				WHERE
					[TeacherId] = @TeacherId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.TeacherDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TeacherDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.TeacherDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the TeacherDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.TeacherDetails_Find
(

	@SearchUsingOR bit   = null ,

	@TeacherId int   = null ,

	@TeacherName nvarchar (50)  = null ,

	@TeacherCertificate int   = null ,

	@Note nvarchar (1024)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [TeacherId]
	, [TeacherName]
	, [TeacherCertificate]
	, [Note]
    FROM
	[dbo].[TeacherDetails]
    WHERE 
	 ([TeacherId] = @TeacherId OR @TeacherId IS NULL)
	AND ([TeacherName] = @TeacherName OR @TeacherName IS NULL)
	AND ([TeacherCertificate] = @TeacherCertificate OR @TeacherCertificate IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [TeacherId]
	, [TeacherName]
	, [TeacherCertificate]
	, [Note]
    FROM
	[dbo].[TeacherDetails]
    WHERE 
	 ([TeacherId] = @TeacherId AND @TeacherId is not null)
	OR ([TeacherName] = @TeacherName AND @TeacherName is not null)
	OR ([TeacherCertificate] = @TeacherCertificate AND @TeacherCertificate is not null)
	OR ([Note] = @Note AND @Note is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ClassTime table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_Get_List

AS


				
				SELECT
					[ClassTimeId],
					[TimeName],
					[Note]
				FROM
					[dbo].[ClassTime]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ClassTime table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ClassTimeId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ClassTimeId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ClassTimeId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClassTime]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[ClassTimeId], O.[TimeName], O.[Note]
				FROM
				    [dbo].[ClassTime] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ClassTimeId] = PageIndex.[ClassTimeId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClassTime]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ClassTime table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_Insert
(

	@ClassTimeId int   ,

	@TimeName nvarchar (50)  ,

	@Note nvarchar (1024)  
)
AS


				
				INSERT INTO [dbo].[ClassTime]
					(
					[ClassTimeId]
					,[TimeName]
					,[Note]
					)
				VALUES
					(
					@ClassTimeId
					,@TimeName
					,@Note
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ClassTime table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_Update
(

	@ClassTimeId int   ,

	@OriginalClassTimeId int   ,

	@TimeName nvarchar (50)  ,

	@Note nvarchar (1024)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClassTime]
				SET
					[ClassTimeId] = @ClassTimeId
					,[TimeName] = @TimeName
					,[Note] = @Note
				WHERE
[ClassTimeId] = @OriginalClassTimeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ClassTime table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_Delete
(

	@ClassTimeId int   
)
AS


				DELETE FROM [dbo].[ClassTime] WITH (ROWLOCK) 
				WHERE
					[ClassTimeId] = @ClassTimeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_GetByClassTimeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_GetByClassTimeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_GetByClassTimeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassTime table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_GetByClassTimeId
(

	@ClassTimeId int   
)
AS


				SELECT
					[ClassTimeId],
					[TimeName],
					[Note]
				FROM
					[dbo].[ClassTime]
				WHERE
					[ClassTimeId] = @ClassTimeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassTime_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassTime_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassTime_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ClassTime table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassTime_Find
(

	@SearchUsingOR bit   = null ,

	@ClassTimeId int   = null ,

	@TimeName nvarchar (50)  = null ,

	@Note nvarchar (1024)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ClassTimeId]
	, [TimeName]
	, [Note]
    FROM
	[dbo].[ClassTime]
    WHERE 
	 ([ClassTimeId] = @ClassTimeId OR @ClassTimeId IS NULL)
	AND ([TimeName] = @TimeName OR @TimeName IS NULL)
	AND ([Note] = @Note OR @Note IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ClassTimeId]
	, [TimeName]
	, [Note]
    FROM
	[dbo].[ClassTime]
    WHERE 
	 ([ClassTimeId] = @ClassTimeId AND @ClassTimeId is not null)
	OR ([TimeName] = @TimeName AND @TimeName is not null)
	OR ([Note] = @Note AND @Note is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ClassDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_Get_List

AS


				
				SELECT
					[ClassId],
					[ClassName],
					[ClassTime],
					[CourseId],
					[TeacherId]
				FROM
					[dbo].[ClassDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ClassDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ClassId] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ClassId])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ClassId]'
				SET @SQL = @SQL + ' FROM [dbo].[ClassDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[ClassId], O.[ClassName], O.[ClassTime], O.[CourseId], O.[TeacherId]
				FROM
				    [dbo].[ClassDetails] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ClassId] = PageIndex.[ClassId]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClassDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ClassDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_Insert
(

	@ClassId int   ,

	@ClassName nvarchar (50)  ,

	@ClassTime int   ,

	@CourseId int   ,

	@TeacherId int   
)
AS


				
				INSERT INTO [dbo].[ClassDetails]
					(
					[ClassId]
					,[ClassName]
					,[ClassTime]
					,[CourseId]
					,[TeacherId]
					)
				VALUES
					(
					@ClassId
					,@ClassName
					,@ClassTime
					,@CourseId
					,@TeacherId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ClassDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_Update
(

	@ClassId int   ,

	@OriginalClassId int   ,

	@ClassName nvarchar (50)  ,

	@ClassTime int   ,

	@CourseId int   ,

	@TeacherId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClassDetails]
				SET
					[ClassId] = @ClassId
					,[ClassName] = @ClassName
					,[ClassTime] = @ClassTime
					,[CourseId] = @CourseId
					,[TeacherId] = @TeacherId
				WHERE
[ClassId] = @OriginalClassId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ClassDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_Delete
(

	@ClassId int   
)
AS


				DELETE FROM [dbo].[ClassDetails] WITH (ROWLOCK) 
				WHERE
					[ClassId] = @ClassId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_GetByClassTime procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_GetByClassTime') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_GetByClassTime
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_GetByClassTime
(

	@ClassTime int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ClassId],
					[ClassName],
					[ClassTime],
					[CourseId],
					[TeacherId]
				FROM
					[dbo].[ClassDetails]
				WHERE
					[ClassTime] = @ClassTime
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_GetByCourseId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_GetByCourseId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_GetByCourseId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_GetByCourseId
(

	@CourseId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ClassId],
					[ClassName],
					[ClassTime],
					[CourseId],
					[TeacherId]
				FROM
					[dbo].[ClassDetails]
				WHERE
					[CourseId] = @CourseId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_GetByTeacherId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_GetByTeacherId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_GetByTeacherId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_GetByTeacherId
(

	@TeacherId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ClassId],
					[ClassName],
					[ClassTime],
					[CourseId],
					[TeacherId]
				FROM
					[dbo].[ClassDetails]
				WHERE
					[TeacherId] = @TeacherId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_GetByClassId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_GetByClassId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_GetByClassId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_GetByClassId
(

	@ClassId int   
)
AS


				SELECT
					[ClassId],
					[ClassName],
					[ClassTime],
					[CourseId],
					[TeacherId]
				FROM
					[dbo].[ClassDetails]
				WHERE
					[ClassId] = @ClassId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ClassDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassDetails_Find
(

	@SearchUsingOR bit   = null ,

	@ClassId int   = null ,

	@ClassName nvarchar (50)  = null ,

	@ClassTime int   = null ,

	@CourseId int   = null ,

	@TeacherId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ClassId]
	, [ClassName]
	, [ClassTime]
	, [CourseId]
	, [TeacherId]
    FROM
	[dbo].[ClassDetails]
    WHERE 
	 ([ClassId] = @ClassId OR @ClassId IS NULL)
	AND ([ClassName] = @ClassName OR @ClassName IS NULL)
	AND ([ClassTime] = @ClassTime OR @ClassTime IS NULL)
	AND ([CourseId] = @CourseId OR @CourseId IS NULL)
	AND ([TeacherId] = @TeacherId OR @TeacherId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ClassId]
	, [ClassName]
	, [ClassTime]
	, [CourseId]
	, [TeacherId]
    FROM
	[dbo].[ClassDetails]
    WHERE 
	 ([ClassId] = @ClassId AND @ClassId is not null)
	OR ([ClassName] = @ClassName AND @ClassName is not null)
	OR ([ClassTime] = @ClassTime AND @ClassTime is not null)
	OR ([CourseId] = @CourseId AND @CourseId is not null)
	OR ([TeacherId] = @TeacherId AND @TeacherId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ClassArrangement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_Get_List

AS


				
				SELECT
					[CustomerId],
					[ClassId],
					[CreateDate]
				FROM
					[dbo].[ClassArrangement]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ClassArrangement table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [CustomerId] int, [ClassId] int, [CreateDate] datetime 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([CustomerId], [ClassId], [CreateDate])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [CustomerId], [ClassId], [CreateDate]'
				SET @SQL = @SQL + ' FROM [dbo].[ClassArrangement]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[CustomerId], O.[ClassId], O.[CreateDate]
				FROM
				    [dbo].[ClassArrangement] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[CustomerId] = PageIndex.[CustomerId]
					AND O.[ClassId] = PageIndex.[ClassId]
					AND O.[CreateDate] = PageIndex.[CreateDate]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ClassArrangement]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ClassArrangement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_Insert
(

	@CustomerId int   ,

	@ClassId int   ,

	@CreateDate datetime   
)
AS


				
				INSERT INTO [dbo].[ClassArrangement]
					(
					[CustomerId]
					,[ClassId]
					,[CreateDate]
					)
				VALUES
					(
					@CustomerId
					,@ClassId
					,@CreateDate
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ClassArrangement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_Update
(

	@CustomerId int   ,

	@OriginalCustomerId int   ,

	@ClassId int   ,

	@OriginalClassId int   ,

	@CreateDate datetime   ,

	@OriginalCreateDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ClassArrangement]
				SET
					[CustomerId] = @CustomerId
					,[ClassId] = @ClassId
					,[CreateDate] = @CreateDate
				WHERE
[CustomerId] = @OriginalCustomerId 
AND [ClassId] = @OriginalClassId 
AND [CreateDate] = @OriginalCreateDate 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ClassArrangement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_Delete
(

	@CustomerId int   ,

	@ClassId int   ,

	@CreateDate datetime   
)
AS


				DELETE FROM [dbo].[ClassArrangement] WITH (ROWLOCK) 
				WHERE
					[CustomerId] = @CustomerId
					AND [ClassId] = @ClassId
					AND [CreateDate] = @CreateDate
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_GetByClassId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_GetByClassId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_GetByClassId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassArrangement table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_GetByClassId
(

	@ClassId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CustomerId],
					[ClassId],
					[CreateDate]
				FROM
					[dbo].[ClassArrangement]
				WHERE
					[ClassId] = @ClassId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassArrangement table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_GetByCustomerId
(

	@CustomerId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CustomerId],
					[ClassId],
					[CreateDate]
				FROM
					[dbo].[ClassArrangement]
				WHERE
					[CustomerId] = @CustomerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_GetByCustomerIdClassIdCreateDate procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_GetByCustomerIdClassIdCreateDate') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_GetByCustomerIdClassIdCreateDate
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ClassArrangement table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_GetByCustomerIdClassIdCreateDate
(

	@CustomerId int   ,

	@ClassId int   ,

	@CreateDate datetime   
)
AS


				SELECT
					[CustomerId],
					[ClassId],
					[CreateDate]
				FROM
					[dbo].[ClassArrangement]
				WHERE
					[CustomerId] = @CustomerId
					AND [ClassId] = @ClassId
					AND [CreateDate] = @CreateDate
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ClassArrangement_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ClassArrangement_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ClassArrangement_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ClassArrangement table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ClassArrangement_Find
(

	@SearchUsingOR bit   = null ,

	@CustomerId int   = null ,

	@ClassId int   = null ,

	@CreateDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CustomerId]
	, [ClassId]
	, [CreateDate]
    FROM
	[dbo].[ClassArrangement]
    WHERE 
	 ([CustomerId] = @CustomerId OR @CustomerId IS NULL)
	AND ([ClassId] = @ClassId OR @ClassId IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CustomerId]
	, [ClassId]
	, [CreateDate]
    FROM
	[dbo].[ClassArrangement]
    WHERE 
	 ([CustomerId] = @CustomerId AND @CustomerId is not null)
	OR ([ClassId] = @ClassId AND @ClassId is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

