
USE [SkinCare]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblNguonDonHang_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblNguonDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_Get_List

AS


				
				SELECT
					[MaNguonDonHang],
					[TenNguonDonHang]
				FROM
					[dbo].[tblNguonDonHang]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblNguonDonHang_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblNguonDonHang table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaNguonDonHang] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaNguonDonHang])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaNguonDonHang]'
				SET @SQL = @SQL + ' FROM [dbo].[tblNguonDonHang]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaNguonDonHang], O.[TenNguonDonHang]
				FROM
				    [dbo].[tblNguonDonHang] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaNguonDonHang] = PageIndex.[MaNguonDonHang]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblNguonDonHang]'
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

	

-- Drop the dbo.tblNguonDonHang_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblNguonDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_Insert
(

	@MaNguonDonHang int   ,

	@TenNguonDonHang nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[tblNguonDonHang]
					(
					[MaNguonDonHang]
					,[TenNguonDonHang]
					)
				VALUES
					(
					@MaNguonDonHang
					,@TenNguonDonHang
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblNguonDonHang_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblNguonDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_Update
(

	@MaNguonDonHang int   ,

	@OriginalMaNguonDonHang int   ,

	@TenNguonDonHang nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblNguonDonHang]
				SET
					[MaNguonDonHang] = @MaNguonDonHang
					,[TenNguonDonHang] = @TenNguonDonHang
				WHERE
[MaNguonDonHang] = @OriginalMaNguonDonHang 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblNguonDonHang_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblNguonDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_Delete
(

	@MaNguonDonHang int   
)
AS


				DELETE FROM [dbo].[tblNguonDonHang] WITH (ROWLOCK) 
				WHERE
					[MaNguonDonHang] = @MaNguonDonHang
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblNguonDonHang_GetByMaNguonDonHang procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_GetByMaNguonDonHang') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_GetByMaNguonDonHang
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblNguonDonHang table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_GetByMaNguonDonHang
(

	@MaNguonDonHang int   
)
AS


				SELECT
					[MaNguonDonHang],
					[TenNguonDonHang]
				FROM
					[dbo].[tblNguonDonHang]
				WHERE
					[MaNguonDonHang] = @MaNguonDonHang
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblNguonDonHang_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblNguonDonHang_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblNguonDonHang_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblNguonDonHang table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblNguonDonHang_Find
(

	@SearchUsingOR bit   = null ,

	@MaNguonDonHang int   = null ,

	@TenNguonDonHang nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaNguonDonHang]
	, [TenNguonDonHang]
    FROM
	[dbo].[tblNguonDonHang]
    WHERE 
	 ([MaNguonDonHang] = @MaNguonDonHang OR @MaNguonDonHang IS NULL)
	AND ([TenNguonDonHang] = @TenNguonDonHang OR @TenNguonDonHang IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaNguonDonHang]
	, [TenNguonDonHang]
    FROM
	[dbo].[tblNguonDonHang]
    WHERE 
	 ([MaNguonDonHang] = @MaNguonDonHang AND @MaNguonDonHang is not null)
	OR ([TenNguonDonHang] = @TenNguonDonHang AND @TenNguonDonHang is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHang_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_Get_List

AS


				
				SELECT
					[MaDonHang],
					[MaKhachHang],
					[MaNguonDonHang],
					[MaTrangThaiDonHang],
					[NguoiDatHang],
					[MaPhuongThucThanhToan],
					[CachThucNhanHang],
					[PhiVanChuyen],
					[TongTienDonHang],
					[NgayTaoDonHang],
					[MaKhuyenMai],
					[MaVoucher],
					[GhiChu],
					[TienChietKhau],
					[TiLeChietKhau]
				FROM
					[dbo].[tblDonHang]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHang_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDonHang table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaDonHang] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaDonHang])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaDonHang]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDonHang]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaDonHang], O.[MaKhachHang], O.[MaNguonDonHang], O.[MaTrangThaiDonHang], O.[NguoiDatHang], O.[MaPhuongThucThanhToan], O.[CachThucNhanHang], O.[PhiVanChuyen], O.[TongTienDonHang], O.[NgayTaoDonHang], O.[MaKhuyenMai], O.[MaVoucher], O.[GhiChu], O.[TienChietKhau], O.[TiLeChietKhau]
				FROM
				    [dbo].[tblDonHang] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaDonHang] = PageIndex.[MaDonHang]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDonHang]'
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

	

-- Drop the dbo.tblDonHang_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_Insert
(

	@MaDonHang int    OUTPUT,

	@MaKhachHang int   ,

	@MaNguonDonHang int   ,

	@MaTrangThaiDonHang int   ,

	@NguoiDatHang nvarchar (100)  ,

	@MaPhuongThucThanhToan int   ,

	@CachThucNhanHang nvarchar (100)  ,

	@PhiVanChuyen decimal (18, 3)  ,

	@TongTienDonHang decimal (18, 3)  ,

	@NgayTaoDonHang datetime   ,

	@MaKhuyenMai nvarchar (100)  ,

	@MaVoucher nvarchar (100)  ,

	@GhiChu nvarchar (MAX)  ,

	@TienChietKhau decimal (18, 3)  ,

	@TiLeChietKhau float   
)
AS


				
				INSERT INTO [dbo].[tblDonHang]
					(
					[MaKhachHang]
					,[MaNguonDonHang]
					,[MaTrangThaiDonHang]
					,[NguoiDatHang]
					,[MaPhuongThucThanhToan]
					,[CachThucNhanHang]
					,[PhiVanChuyen]
					,[TongTienDonHang]
					,[NgayTaoDonHang]
					,[MaKhuyenMai]
					,[MaVoucher]
					,[GhiChu]
					,[TienChietKhau]
					,[TiLeChietKhau]
					)
				VALUES
					(
					@MaKhachHang
					,@MaNguonDonHang
					,@MaTrangThaiDonHang
					,@NguoiDatHang
					,@MaPhuongThucThanhToan
					,@CachThucNhanHang
					,@PhiVanChuyen
					,@TongTienDonHang
					,@NgayTaoDonHang
					,@MaKhuyenMai
					,@MaVoucher
					,@GhiChu
					,@TienChietKhau
					,@TiLeChietKhau
					)
				-- Get the identity value
				SET @MaDonHang = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHang_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_Update
(

	@MaDonHang int   ,

	@MaKhachHang int   ,

	@MaNguonDonHang int   ,

	@MaTrangThaiDonHang int   ,

	@NguoiDatHang nvarchar (100)  ,

	@MaPhuongThucThanhToan int   ,

	@CachThucNhanHang nvarchar (100)  ,

	@PhiVanChuyen decimal (18, 3)  ,

	@TongTienDonHang decimal (18, 3)  ,

	@NgayTaoDonHang datetime   ,

	@MaKhuyenMai nvarchar (100)  ,

	@MaVoucher nvarchar (100)  ,

	@GhiChu nvarchar (MAX)  ,

	@TienChietKhau decimal (18, 3)  ,

	@TiLeChietKhau float   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDonHang]
				SET
					[MaKhachHang] = @MaKhachHang
					,[MaNguonDonHang] = @MaNguonDonHang
					,[MaTrangThaiDonHang] = @MaTrangThaiDonHang
					,[NguoiDatHang] = @NguoiDatHang
					,[MaPhuongThucThanhToan] = @MaPhuongThucThanhToan
					,[CachThucNhanHang] = @CachThucNhanHang
					,[PhiVanChuyen] = @PhiVanChuyen
					,[TongTienDonHang] = @TongTienDonHang
					,[NgayTaoDonHang] = @NgayTaoDonHang
					,[MaKhuyenMai] = @MaKhuyenMai
					,[MaVoucher] = @MaVoucher
					,[GhiChu] = @GhiChu
					,[TienChietKhau] = @TienChietKhau
					,[TiLeChietKhau] = @TiLeChietKhau
				WHERE
[MaDonHang] = @MaDonHang 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHang_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_Delete
(

	@MaDonHang int   
)
AS


				DELETE FROM [dbo].[tblDonHang] WITH (ROWLOCK) 
				WHERE
					[MaDonHang] = @MaDonHang
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHang_GetByMaDonHang procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_GetByMaDonHang') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_GetByMaDonHang
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDonHang table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_GetByMaDonHang
(

	@MaDonHang int   
)
AS


				SELECT
					[MaDonHang],
					[MaKhachHang],
					[MaNguonDonHang],
					[MaTrangThaiDonHang],
					[NguoiDatHang],
					[MaPhuongThucThanhToan],
					[CachThucNhanHang],
					[PhiVanChuyen],
					[TongTienDonHang],
					[NgayTaoDonHang],
					[MaKhuyenMai],
					[MaVoucher],
					[GhiChu],
					[TienChietKhau],
					[TiLeChietKhau]
				FROM
					[dbo].[tblDonHang]
				WHERE
					[MaDonHang] = @MaDonHang
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHang_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHang_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHang_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDonHang table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHang_Find
(

	@SearchUsingOR bit   = null ,

	@MaDonHang int   = null ,

	@MaKhachHang int   = null ,

	@MaNguonDonHang int   = null ,

	@MaTrangThaiDonHang int   = null ,

	@NguoiDatHang nvarchar (100)  = null ,

	@MaPhuongThucThanhToan int   = null ,

	@CachThucNhanHang nvarchar (100)  = null ,

	@PhiVanChuyen decimal (18, 3)  = null ,

	@TongTienDonHang decimal (18, 3)  = null ,

	@NgayTaoDonHang datetime   = null ,

	@MaKhuyenMai nvarchar (100)  = null ,

	@MaVoucher nvarchar (100)  = null ,

	@GhiChu nvarchar (MAX)  = null ,

	@TienChietKhau decimal (18, 3)  = null ,

	@TiLeChietKhau float   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaDonHang]
	, [MaKhachHang]
	, [MaNguonDonHang]
	, [MaTrangThaiDonHang]
	, [NguoiDatHang]
	, [MaPhuongThucThanhToan]
	, [CachThucNhanHang]
	, [PhiVanChuyen]
	, [TongTienDonHang]
	, [NgayTaoDonHang]
	, [MaKhuyenMai]
	, [MaVoucher]
	, [GhiChu]
	, [TienChietKhau]
	, [TiLeChietKhau]
    FROM
	[dbo].[tblDonHang]
    WHERE 
	 ([MaDonHang] = @MaDonHang OR @MaDonHang IS NULL)
	AND ([MaKhachHang] = @MaKhachHang OR @MaKhachHang IS NULL)
	AND ([MaNguonDonHang] = @MaNguonDonHang OR @MaNguonDonHang IS NULL)
	AND ([MaTrangThaiDonHang] = @MaTrangThaiDonHang OR @MaTrangThaiDonHang IS NULL)
	AND ([NguoiDatHang] = @NguoiDatHang OR @NguoiDatHang IS NULL)
	AND ([MaPhuongThucThanhToan] = @MaPhuongThucThanhToan OR @MaPhuongThucThanhToan IS NULL)
	AND ([CachThucNhanHang] = @CachThucNhanHang OR @CachThucNhanHang IS NULL)
	AND ([PhiVanChuyen] = @PhiVanChuyen OR @PhiVanChuyen IS NULL)
	AND ([TongTienDonHang] = @TongTienDonHang OR @TongTienDonHang IS NULL)
	AND ([NgayTaoDonHang] = @NgayTaoDonHang OR @NgayTaoDonHang IS NULL)
	AND ([MaKhuyenMai] = @MaKhuyenMai OR @MaKhuyenMai IS NULL)
	AND ([MaVoucher] = @MaVoucher OR @MaVoucher IS NULL)
	AND ([GhiChu] = @GhiChu OR @GhiChu IS NULL)
	AND ([TienChietKhau] = @TienChietKhau OR @TienChietKhau IS NULL)
	AND ([TiLeChietKhau] = @TiLeChietKhau OR @TiLeChietKhau IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaDonHang]
	, [MaKhachHang]
	, [MaNguonDonHang]
	, [MaTrangThaiDonHang]
	, [NguoiDatHang]
	, [MaPhuongThucThanhToan]
	, [CachThucNhanHang]
	, [PhiVanChuyen]
	, [TongTienDonHang]
	, [NgayTaoDonHang]
	, [MaKhuyenMai]
	, [MaVoucher]
	, [GhiChu]
	, [TienChietKhau]
	, [TiLeChietKhau]
    FROM
	[dbo].[tblDonHang]
    WHERE 
	 ([MaDonHang] = @MaDonHang AND @MaDonHang is not null)
	OR ([MaKhachHang] = @MaKhachHang AND @MaKhachHang is not null)
	OR ([MaNguonDonHang] = @MaNguonDonHang AND @MaNguonDonHang is not null)
	OR ([MaTrangThaiDonHang] = @MaTrangThaiDonHang AND @MaTrangThaiDonHang is not null)
	OR ([NguoiDatHang] = @NguoiDatHang AND @NguoiDatHang is not null)
	OR ([MaPhuongThucThanhToan] = @MaPhuongThucThanhToan AND @MaPhuongThucThanhToan is not null)
	OR ([CachThucNhanHang] = @CachThucNhanHang AND @CachThucNhanHang is not null)
	OR ([PhiVanChuyen] = @PhiVanChuyen AND @PhiVanChuyen is not null)
	OR ([TongTienDonHang] = @TongTienDonHang AND @TongTienDonHang is not null)
	OR ([NgayTaoDonHang] = @NgayTaoDonHang AND @NgayTaoDonHang is not null)
	OR ([MaKhuyenMai] = @MaKhuyenMai AND @MaKhuyenMai is not null)
	OR ([MaVoucher] = @MaVoucher AND @MaVoucher is not null)
	OR ([GhiChu] = @GhiChu AND @GhiChu is not null)
	OR ([TienChietKhau] = @TienChietKhau AND @TienChietKhau is not null)
	OR ([TiLeChietKhau] = @TiLeChietKhau AND @TiLeChietKhau is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblLoaiTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_Get_List

AS


				
				SELECT
					[MaLoaiTrangThai],
					[TenLoaiTrangThai]
				FROM
					[dbo].[tblLoaiTrangThaiDonHang]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblLoaiTrangThaiDonHang table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaLoaiTrangThai] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaLoaiTrangThai])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaLoaiTrangThai]'
				SET @SQL = @SQL + ' FROM [dbo].[tblLoaiTrangThaiDonHang]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaLoaiTrangThai], O.[TenLoaiTrangThai]
				FROM
				    [dbo].[tblLoaiTrangThaiDonHang] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaLoaiTrangThai] = PageIndex.[MaLoaiTrangThai]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblLoaiTrangThaiDonHang]'
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

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblLoaiTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_Insert
(

	@MaLoaiTrangThai int   ,

	@TenLoaiTrangThai nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[tblLoaiTrangThaiDonHang]
					(
					[MaLoaiTrangThai]
					,[TenLoaiTrangThai]
					)
				VALUES
					(
					@MaLoaiTrangThai
					,@TenLoaiTrangThai
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblLoaiTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_Update
(

	@MaLoaiTrangThai int   ,

	@OriginalMaLoaiTrangThai int   ,

	@TenLoaiTrangThai nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblLoaiTrangThaiDonHang]
				SET
					[MaLoaiTrangThai] = @MaLoaiTrangThai
					,[TenLoaiTrangThai] = @TenLoaiTrangThai
				WHERE
[MaLoaiTrangThai] = @OriginalMaLoaiTrangThai 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblLoaiTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_Delete
(

	@MaLoaiTrangThai int   
)
AS


				DELETE FROM [dbo].[tblLoaiTrangThaiDonHang] WITH (ROWLOCK) 
				WHERE
					[MaLoaiTrangThai] = @MaLoaiTrangThai
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_GetByMaLoaiTrangThai procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_GetByMaLoaiTrangThai') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_GetByMaLoaiTrangThai
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblLoaiTrangThaiDonHang table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_GetByMaLoaiTrangThai
(

	@MaLoaiTrangThai int   
)
AS


				SELECT
					[MaLoaiTrangThai],
					[TenLoaiTrangThai]
				FROM
					[dbo].[tblLoaiTrangThaiDonHang]
				WHERE
					[MaLoaiTrangThai] = @MaLoaiTrangThai
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblLoaiTrangThaiDonHang_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblLoaiTrangThaiDonHang_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblLoaiTrangThaiDonHang_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblLoaiTrangThaiDonHang table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblLoaiTrangThaiDonHang_Find
(

	@SearchUsingOR bit   = null ,

	@MaLoaiTrangThai int   = null ,

	@TenLoaiTrangThai nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaLoaiTrangThai]
	, [TenLoaiTrangThai]
    FROM
	[dbo].[tblLoaiTrangThaiDonHang]
    WHERE 
	 ([MaLoaiTrangThai] = @MaLoaiTrangThai OR @MaLoaiTrangThai IS NULL)
	AND ([TenLoaiTrangThai] = @TenLoaiTrangThai OR @TenLoaiTrangThai IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaLoaiTrangThai]
	, [TenLoaiTrangThai]
    FROM
	[dbo].[tblLoaiTrangThaiDonHang]
    WHERE 
	 ([MaLoaiTrangThai] = @MaLoaiTrangThai AND @MaLoaiTrangThai is not null)
	OR ([TenLoaiTrangThai] = @TenLoaiTrangThai AND @TenLoaiTrangThai is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPhuongThucThanhToan_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblPhuongThucThanhToan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_Get_List

AS


				
				SELECT
					[MaPhuongThucThanhToan],
					[TenPhuongThucThanhToan]
				FROM
					[dbo].[tblPhuongThucThanhToan]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPhuongThucThanhToan_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblPhuongThucThanhToan table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaPhuongThucThanhToan] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaPhuongThucThanhToan])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaPhuongThucThanhToan]'
				SET @SQL = @SQL + ' FROM [dbo].[tblPhuongThucThanhToan]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaPhuongThucThanhToan], O.[TenPhuongThucThanhToan]
				FROM
				    [dbo].[tblPhuongThucThanhToan] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaPhuongThucThanhToan] = PageIndex.[MaPhuongThucThanhToan]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblPhuongThucThanhToan]'
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

	

-- Drop the dbo.tblPhuongThucThanhToan_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblPhuongThucThanhToan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_Insert
(

	@MaPhuongThucThanhToan int    OUTPUT,

	@TenPhuongThucThanhToan nvarchar (100)  
)
AS


				
				INSERT INTO [dbo].[tblPhuongThucThanhToan]
					(
					[TenPhuongThucThanhToan]
					)
				VALUES
					(
					@TenPhuongThucThanhToan
					)
				-- Get the identity value
				SET @MaPhuongThucThanhToan = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPhuongThucThanhToan_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblPhuongThucThanhToan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_Update
(

	@MaPhuongThucThanhToan int   ,

	@TenPhuongThucThanhToan nvarchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblPhuongThucThanhToan]
				SET
					[TenPhuongThucThanhToan] = @TenPhuongThucThanhToan
				WHERE
[MaPhuongThucThanhToan] = @MaPhuongThucThanhToan 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPhuongThucThanhToan_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblPhuongThucThanhToan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_Delete
(

	@MaPhuongThucThanhToan int   
)
AS


				DELETE FROM [dbo].[tblPhuongThucThanhToan] WITH (ROWLOCK) 
				WHERE
					[MaPhuongThucThanhToan] = @MaPhuongThucThanhToan
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPhuongThucThanhToan_GetByMaPhuongThucThanhToan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_GetByMaPhuongThucThanhToan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_GetByMaPhuongThucThanhToan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblPhuongThucThanhToan table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_GetByMaPhuongThucThanhToan
(

	@MaPhuongThucThanhToan int   
)
AS


				SELECT
					[MaPhuongThucThanhToan],
					[TenPhuongThucThanhToan]
				FROM
					[dbo].[tblPhuongThucThanhToan]
				WHERE
					[MaPhuongThucThanhToan] = @MaPhuongThucThanhToan
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblPhuongThucThanhToan_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblPhuongThucThanhToan_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblPhuongThucThanhToan_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblPhuongThucThanhToan table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblPhuongThucThanhToan_Find
(

	@SearchUsingOR bit   = null ,

	@MaPhuongThucThanhToan int   = null ,

	@TenPhuongThucThanhToan nvarchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaPhuongThucThanhToan]
	, [TenPhuongThucThanhToan]
    FROM
	[dbo].[tblPhuongThucThanhToan]
    WHERE 
	 ([MaPhuongThucThanhToan] = @MaPhuongThucThanhToan OR @MaPhuongThucThanhToan IS NULL)
	AND ([TenPhuongThucThanhToan] = @TenPhuongThucThanhToan OR @TenPhuongThucThanhToan IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaPhuongThucThanhToan]
	, [TenPhuongThucThanhToan]
    FROM
	[dbo].[tblPhuongThucThanhToan]
    WHERE 
	 ([MaPhuongThucThanhToan] = @MaPhuongThucThanhToan AND @MaPhuongThucThanhToan is not null)
	OR ([TenPhuongThucThanhToan] = @TenPhuongThucThanhToan AND @TenPhuongThucThanhToan is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhuyenMai_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblKhuyenMai table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_Get_List

AS


				
				SELECT
					[MaKhuyenMai],
					[MaLoaiKhuyenMai],
					[TenKhuyenMai],
					[GiaGiam],
					[NgayTaoKhuyenMai],
					[NgayBatDauKhuyenMai],
					[NgayKetThucKhuyenMai],
					[Active]
				FROM
					[dbo].[tblKhuyenMai]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhuyenMai_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblKhuyenMai table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaKhuyenMai] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaKhuyenMai])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaKhuyenMai]'
				SET @SQL = @SQL + ' FROM [dbo].[tblKhuyenMai]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaKhuyenMai], O.[MaLoaiKhuyenMai], O.[TenKhuyenMai], O.[GiaGiam], O.[NgayTaoKhuyenMai], O.[NgayBatDauKhuyenMai], O.[NgayKetThucKhuyenMai], O.[Active]
				FROM
				    [dbo].[tblKhuyenMai] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaKhuyenMai] = PageIndex.[MaKhuyenMai]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblKhuyenMai]'
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

	

-- Drop the dbo.tblKhuyenMai_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblKhuyenMai table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_Insert
(

	@MaKhuyenMai int   ,

	@MaLoaiKhuyenMai int   ,

	@TenKhuyenMai nvarchar (100)  ,

	@GiaGiam decimal (18, 3)  ,

	@NgayTaoKhuyenMai datetime   ,

	@NgayBatDauKhuyenMai datetime   ,

	@NgayKetThucKhuyenMai datetime   ,

	@Active bit   
)
AS


				
				INSERT INTO [dbo].[tblKhuyenMai]
					(
					[MaKhuyenMai]
					,[MaLoaiKhuyenMai]
					,[TenKhuyenMai]
					,[GiaGiam]
					,[NgayTaoKhuyenMai]
					,[NgayBatDauKhuyenMai]
					,[NgayKetThucKhuyenMai]
					,[Active]
					)
				VALUES
					(
					@MaKhuyenMai
					,@MaLoaiKhuyenMai
					,@TenKhuyenMai
					,@GiaGiam
					,@NgayTaoKhuyenMai
					,@NgayBatDauKhuyenMai
					,@NgayKetThucKhuyenMai
					,@Active
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhuyenMai_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblKhuyenMai table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_Update
(

	@MaKhuyenMai int   ,

	@OriginalMaKhuyenMai int   ,

	@MaLoaiKhuyenMai int   ,

	@TenKhuyenMai nvarchar (100)  ,

	@GiaGiam decimal (18, 3)  ,

	@NgayTaoKhuyenMai datetime   ,

	@NgayBatDauKhuyenMai datetime   ,

	@NgayKetThucKhuyenMai datetime   ,

	@Active bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblKhuyenMai]
				SET
					[MaKhuyenMai] = @MaKhuyenMai
					,[MaLoaiKhuyenMai] = @MaLoaiKhuyenMai
					,[TenKhuyenMai] = @TenKhuyenMai
					,[GiaGiam] = @GiaGiam
					,[NgayTaoKhuyenMai] = @NgayTaoKhuyenMai
					,[NgayBatDauKhuyenMai] = @NgayBatDauKhuyenMai
					,[NgayKetThucKhuyenMai] = @NgayKetThucKhuyenMai
					,[Active] = @Active
				WHERE
[MaKhuyenMai] = @OriginalMaKhuyenMai 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhuyenMai_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblKhuyenMai table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_Delete
(

	@MaKhuyenMai int   
)
AS


				DELETE FROM [dbo].[tblKhuyenMai] WITH (ROWLOCK) 
				WHERE
					[MaKhuyenMai] = @MaKhuyenMai
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhuyenMai_GetByMaKhuyenMai procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_GetByMaKhuyenMai') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_GetByMaKhuyenMai
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblKhuyenMai table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_GetByMaKhuyenMai
(

	@MaKhuyenMai int   
)
AS


				SELECT
					[MaKhuyenMai],
					[MaLoaiKhuyenMai],
					[TenKhuyenMai],
					[GiaGiam],
					[NgayTaoKhuyenMai],
					[NgayBatDauKhuyenMai],
					[NgayKetThucKhuyenMai],
					[Active]
				FROM
					[dbo].[tblKhuyenMai]
				WHERE
					[MaKhuyenMai] = @MaKhuyenMai
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhuyenMai_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhuyenMai_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhuyenMai_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblKhuyenMai table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhuyenMai_Find
(

	@SearchUsingOR bit   = null ,

	@MaKhuyenMai int   = null ,

	@MaLoaiKhuyenMai int   = null ,

	@TenKhuyenMai nvarchar (100)  = null ,

	@GiaGiam decimal (18, 3)  = null ,

	@NgayTaoKhuyenMai datetime   = null ,

	@NgayBatDauKhuyenMai datetime   = null ,

	@NgayKetThucKhuyenMai datetime   = null ,

	@Active bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaKhuyenMai]
	, [MaLoaiKhuyenMai]
	, [TenKhuyenMai]
	, [GiaGiam]
	, [NgayTaoKhuyenMai]
	, [NgayBatDauKhuyenMai]
	, [NgayKetThucKhuyenMai]
	, [Active]
    FROM
	[dbo].[tblKhuyenMai]
    WHERE 
	 ([MaKhuyenMai] = @MaKhuyenMai OR @MaKhuyenMai IS NULL)
	AND ([MaLoaiKhuyenMai] = @MaLoaiKhuyenMai OR @MaLoaiKhuyenMai IS NULL)
	AND ([TenKhuyenMai] = @TenKhuyenMai OR @TenKhuyenMai IS NULL)
	AND ([GiaGiam] = @GiaGiam OR @GiaGiam IS NULL)
	AND ([NgayTaoKhuyenMai] = @NgayTaoKhuyenMai OR @NgayTaoKhuyenMai IS NULL)
	AND ([NgayBatDauKhuyenMai] = @NgayBatDauKhuyenMai OR @NgayBatDauKhuyenMai IS NULL)
	AND ([NgayKetThucKhuyenMai] = @NgayKetThucKhuyenMai OR @NgayKetThucKhuyenMai IS NULL)
	AND ([Active] = @Active OR @Active IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaKhuyenMai]
	, [MaLoaiKhuyenMai]
	, [TenKhuyenMai]
	, [GiaGiam]
	, [NgayTaoKhuyenMai]
	, [NgayBatDauKhuyenMai]
	, [NgayKetThucKhuyenMai]
	, [Active]
    FROM
	[dbo].[tblKhuyenMai]
    WHERE 
	 ([MaKhuyenMai] = @MaKhuyenMai AND @MaKhuyenMai is not null)
	OR ([MaLoaiKhuyenMai] = @MaLoaiKhuyenMai AND @MaLoaiKhuyenMai is not null)
	OR ([TenKhuyenMai] = @TenKhuyenMai AND @TenKhuyenMai is not null)
	OR ([GiaGiam] = @GiaGiam AND @GiaGiam is not null)
	OR ([NgayTaoKhuyenMai] = @NgayTaoKhuyenMai AND @NgayTaoKhuyenMai is not null)
	OR ([NgayBatDauKhuyenMai] = @NgayBatDauKhuyenMai AND @NgayBatDauKhuyenMai is not null)
	OR ([NgayKetThucKhuyenMai] = @NgayKetThucKhuyenMai AND @NgayKetThucKhuyenMai is not null)
	OR ([Active] = @Active AND @Active is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHangChiTiet_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblDonHangChiTiet table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_Get_List

AS


				
				SELECT
					[ID],
					[MaDonHang],
					[MaSanPham],
					[DonGia],
					[SoLuong],
					[ThanhTien]
				FROM
					[dbo].[tblDonHangChiTiet]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHangChiTiet_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblDonHangChiTiet table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[tblDonHangChiTiet]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[MaDonHang], O.[MaSanPham], O.[DonGia], O.[SoLuong], O.[ThanhTien]
				FROM
				    [dbo].[tblDonHangChiTiet] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblDonHangChiTiet]'
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

	

-- Drop the dbo.tblDonHangChiTiet_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblDonHangChiTiet table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_Insert
(

	@Id int    OUTPUT,

	@MaDonHang int   ,

	@MaSanPham int   ,

	@DonGia decimal (18, 3)  ,

	@SoLuong int   ,

	@ThanhTien decimal (18, 3)  
)
AS


				
				INSERT INTO [dbo].[tblDonHangChiTiet]
					(
					[MaDonHang]
					,[MaSanPham]
					,[DonGia]
					,[SoLuong]
					,[ThanhTien]
					)
				VALUES
					(
					@MaDonHang
					,@MaSanPham
					,@DonGia
					,@SoLuong
					,@ThanhTien
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHangChiTiet_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblDonHangChiTiet table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_Update
(

	@Id int   ,

	@MaDonHang int   ,

	@MaSanPham int   ,

	@DonGia decimal (18, 3)  ,

	@SoLuong int   ,

	@ThanhTien decimal (18, 3)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblDonHangChiTiet]
				SET
					[MaDonHang] = @MaDonHang
					,[MaSanPham] = @MaSanPham
					,[DonGia] = @DonGia
					,[SoLuong] = @SoLuong
					,[ThanhTien] = @ThanhTien
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHangChiTiet_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblDonHangChiTiet table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[tblDonHangChiTiet] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHangChiTiet_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblDonHangChiTiet table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[MaDonHang],
					[MaSanPham],
					[DonGia],
					[SoLuong],
					[ThanhTien]
				FROM
					[dbo].[tblDonHangChiTiet]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblDonHangChiTiet_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblDonHangChiTiet_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblDonHangChiTiet_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblDonHangChiTiet table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblDonHangChiTiet_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@MaDonHang int   = null ,

	@MaSanPham int   = null ,

	@DonGia decimal (18, 3)  = null ,

	@SoLuong int   = null ,

	@ThanhTien decimal (18, 3)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [MaDonHang]
	, [MaSanPham]
	, [DonGia]
	, [SoLuong]
	, [ThanhTien]
    FROM
	[dbo].[tblDonHangChiTiet]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([MaDonHang] = @MaDonHang OR @MaDonHang IS NULL)
	AND ([MaSanPham] = @MaSanPham OR @MaSanPham IS NULL)
	AND ([DonGia] = @DonGia OR @DonGia IS NULL)
	AND ([SoLuong] = @SoLuong OR @SoLuong IS NULL)
	AND ([ThanhTien] = @ThanhTien OR @ThanhTien IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [MaDonHang]
	, [MaSanPham]
	, [DonGia]
	, [SoLuong]
	, [ThanhTien]
    FROM
	[dbo].[tblDonHangChiTiet]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([MaDonHang] = @MaDonHang AND @MaDonHang is not null)
	OR ([MaSanPham] = @MaSanPham AND @MaSanPham is not null)
	OR ([DonGia] = @DonGia AND @DonGia is not null)
	OR ([SoLuong] = @SoLuong AND @SoLuong is not null)
	OR ([ThanhTien] = @ThanhTien AND @ThanhTien is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhoHangSanPham_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblKhoHangSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_Get_List

AS


				
				SELECT
					[MaSanPham],
					[TenSanPham],
					[GiaTien],
					[SoLuongNhapVao],
					[SoLuongBanRa],
					[SoLuongTonKho],
					[NgayNhapHang],
					[GhiChu]
				FROM
					[dbo].[tblKhoHangSanPham]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhoHangSanPham_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblKhoHangSanPham table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaSanPham] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaSanPham])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaSanPham]'
				SET @SQL = @SQL + ' FROM [dbo].[tblKhoHangSanPham]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaSanPham], O.[TenSanPham], O.[GiaTien], O.[SoLuongNhapVao], O.[SoLuongBanRa], O.[SoLuongTonKho], O.[NgayNhapHang], O.[GhiChu]
				FROM
				    [dbo].[tblKhoHangSanPham] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaSanPham] = PageIndex.[MaSanPham]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblKhoHangSanPham]'
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

	

-- Drop the dbo.tblKhoHangSanPham_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblKhoHangSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_Insert
(

	@MaSanPham int    OUTPUT,

	@TenSanPham nvarchar (100)  ,

	@GiaTien decimal (18, 3)  ,

	@SoLuongNhapVao int   ,

	@SoLuongBanRa int   ,

	@SoLuongTonKho int   ,

	@NgayNhapHang datetime   ,

	@GhiChu nvarchar (MAX)  
)
AS


				
				INSERT INTO [dbo].[tblKhoHangSanPham]
					(
					[TenSanPham]
					,[GiaTien]
					,[SoLuongNhapVao]
					,[SoLuongBanRa]
					,[SoLuongTonKho]
					,[NgayNhapHang]
					,[GhiChu]
					)
				VALUES
					(
					@TenSanPham
					,@GiaTien
					,@SoLuongNhapVao
					,@SoLuongBanRa
					,@SoLuongTonKho
					,@NgayNhapHang
					,@GhiChu
					)
				-- Get the identity value
				SET @MaSanPham = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhoHangSanPham_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblKhoHangSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_Update
(

	@MaSanPham int   ,

	@TenSanPham nvarchar (100)  ,

	@GiaTien decimal (18, 3)  ,

	@SoLuongNhapVao int   ,

	@SoLuongBanRa int   ,

	@SoLuongTonKho int   ,

	@NgayNhapHang datetime   ,

	@GhiChu nvarchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblKhoHangSanPham]
				SET
					[TenSanPham] = @TenSanPham
					,[GiaTien] = @GiaTien
					,[SoLuongNhapVao] = @SoLuongNhapVao
					,[SoLuongBanRa] = @SoLuongBanRa
					,[SoLuongTonKho] = @SoLuongTonKho
					,[NgayNhapHang] = @NgayNhapHang
					,[GhiChu] = @GhiChu
				WHERE
[MaSanPham] = @MaSanPham 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhoHangSanPham_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblKhoHangSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_Delete
(

	@MaSanPham int   
)
AS


				DELETE FROM [dbo].[tblKhoHangSanPham] WITH (ROWLOCK) 
				WHERE
					[MaSanPham] = @MaSanPham
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhoHangSanPham_GetByMaSanPham procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_GetByMaSanPham') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_GetByMaSanPham
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblKhoHangSanPham table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_GetByMaSanPham
(

	@MaSanPham int   
)
AS


				SELECT
					[MaSanPham],
					[TenSanPham],
					[GiaTien],
					[SoLuongNhapVao],
					[SoLuongBanRa],
					[SoLuongTonKho],
					[NgayNhapHang],
					[GhiChu]
				FROM
					[dbo].[tblKhoHangSanPham]
				WHERE
					[MaSanPham] = @MaSanPham
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhoHangSanPham_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhoHangSanPham_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhoHangSanPham_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblKhoHangSanPham table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhoHangSanPham_Find
(

	@SearchUsingOR bit   = null ,

	@MaSanPham int   = null ,

	@TenSanPham nvarchar (100)  = null ,

	@GiaTien decimal (18, 3)  = null ,

	@SoLuongNhapVao int   = null ,

	@SoLuongBanRa int   = null ,

	@SoLuongTonKho int   = null ,

	@NgayNhapHang datetime   = null ,

	@GhiChu nvarchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaSanPham]
	, [TenSanPham]
	, [GiaTien]
	, [SoLuongNhapVao]
	, [SoLuongBanRa]
	, [SoLuongTonKho]
	, [NgayNhapHang]
	, [GhiChu]
    FROM
	[dbo].[tblKhoHangSanPham]
    WHERE 
	 ([MaSanPham] = @MaSanPham OR @MaSanPham IS NULL)
	AND ([TenSanPham] = @TenSanPham OR @TenSanPham IS NULL)
	AND ([GiaTien] = @GiaTien OR @GiaTien IS NULL)
	AND ([SoLuongNhapVao] = @SoLuongNhapVao OR @SoLuongNhapVao IS NULL)
	AND ([SoLuongBanRa] = @SoLuongBanRa OR @SoLuongBanRa IS NULL)
	AND ([SoLuongTonKho] = @SoLuongTonKho OR @SoLuongTonKho IS NULL)
	AND ([NgayNhapHang] = @NgayNhapHang OR @NgayNhapHang IS NULL)
	AND ([GhiChu] = @GhiChu OR @GhiChu IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaSanPham]
	, [TenSanPham]
	, [GiaTien]
	, [SoLuongNhapVao]
	, [SoLuongBanRa]
	, [SoLuongTonKho]
	, [NgayNhapHang]
	, [GhiChu]
    FROM
	[dbo].[tblKhoHangSanPham]
    WHERE 
	 ([MaSanPham] = @MaSanPham AND @MaSanPham is not null)
	OR ([TenSanPham] = @TenSanPham AND @TenSanPham is not null)
	OR ([GiaTien] = @GiaTien AND @GiaTien is not null)
	OR ([SoLuongNhapVao] = @SoLuongNhapVao AND @SoLuongNhapVao is not null)
	OR ([SoLuongBanRa] = @SoLuongBanRa AND @SoLuongBanRa is not null)
	OR ([SoLuongTonKho] = @SoLuongTonKho AND @SoLuongTonKho is not null)
	OR ([NgayNhapHang] = @NgayNhapHang AND @NgayNhapHang is not null)
	OR ([GhiChu] = @GhiChu AND @GhiChu is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblTrangThaiDonHang_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_Get_List

AS


				
				SELECT
					[MaTrangThaiDonHang],
					[MaLoaiTrangThaiDonHang],
					[TenLoaiTrangThaiDonHang]
				FROM
					[dbo].[tblTrangThaiDonHang]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblTrangThaiDonHang_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblTrangThaiDonHang table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaTrangThaiDonHang] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaTrangThaiDonHang])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaTrangThaiDonHang]'
				SET @SQL = @SQL + ' FROM [dbo].[tblTrangThaiDonHang]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaTrangThaiDonHang], O.[MaLoaiTrangThaiDonHang], O.[TenLoaiTrangThaiDonHang]
				FROM
				    [dbo].[tblTrangThaiDonHang] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaTrangThaiDonHang] = PageIndex.[MaTrangThaiDonHang]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblTrangThaiDonHang]'
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

	

-- Drop the dbo.tblTrangThaiDonHang_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_Insert
(

	@MaTrangThaiDonHang int   ,

	@MaLoaiTrangThaiDonHang int   ,

	@TenLoaiTrangThaiDonHang nvarchar (100)  
)
AS


				
				INSERT INTO [dbo].[tblTrangThaiDonHang]
					(
					[MaTrangThaiDonHang]
					,[MaLoaiTrangThaiDonHang]
					,[TenLoaiTrangThaiDonHang]
					)
				VALUES
					(
					@MaTrangThaiDonHang
					,@MaLoaiTrangThaiDonHang
					,@TenLoaiTrangThaiDonHang
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblTrangThaiDonHang_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_Update
(

	@MaTrangThaiDonHang int   ,

	@OriginalMaTrangThaiDonHang int   ,

	@MaLoaiTrangThaiDonHang int   ,

	@TenLoaiTrangThaiDonHang nvarchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblTrangThaiDonHang]
				SET
					[MaTrangThaiDonHang] = @MaTrangThaiDonHang
					,[MaLoaiTrangThaiDonHang] = @MaLoaiTrangThaiDonHang
					,[TenLoaiTrangThaiDonHang] = @TenLoaiTrangThaiDonHang
				WHERE
[MaTrangThaiDonHang] = @OriginalMaTrangThaiDonHang 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblTrangThaiDonHang_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblTrangThaiDonHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_Delete
(

	@MaTrangThaiDonHang int   
)
AS


				DELETE FROM [dbo].[tblTrangThaiDonHang] WITH (ROWLOCK) 
				WHERE
					[MaTrangThaiDonHang] = @MaTrangThaiDonHang
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblTrangThaiDonHang_GetByMaTrangThaiDonHang procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_GetByMaTrangThaiDonHang') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_GetByMaTrangThaiDonHang
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblTrangThaiDonHang table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_GetByMaTrangThaiDonHang
(

	@MaTrangThaiDonHang int   
)
AS


				SELECT
					[MaTrangThaiDonHang],
					[MaLoaiTrangThaiDonHang],
					[TenLoaiTrangThaiDonHang]
				FROM
					[dbo].[tblTrangThaiDonHang]
				WHERE
					[MaTrangThaiDonHang] = @MaTrangThaiDonHang
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblTrangThaiDonHang_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblTrangThaiDonHang_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblTrangThaiDonHang_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblTrangThaiDonHang table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblTrangThaiDonHang_Find
(

	@SearchUsingOR bit   = null ,

	@MaTrangThaiDonHang int   = null ,

	@MaLoaiTrangThaiDonHang int   = null ,

	@TenLoaiTrangThaiDonHang nvarchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaTrangThaiDonHang]
	, [MaLoaiTrangThaiDonHang]
	, [TenLoaiTrangThaiDonHang]
    FROM
	[dbo].[tblTrangThaiDonHang]
    WHERE 
	 ([MaTrangThaiDonHang] = @MaTrangThaiDonHang OR @MaTrangThaiDonHang IS NULL)
	AND ([MaLoaiTrangThaiDonHang] = @MaLoaiTrangThaiDonHang OR @MaLoaiTrangThaiDonHang IS NULL)
	AND ([TenLoaiTrangThaiDonHang] = @TenLoaiTrangThaiDonHang OR @TenLoaiTrangThaiDonHang IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaTrangThaiDonHang]
	, [MaLoaiTrangThaiDonHang]
	, [TenLoaiTrangThaiDonHang]
    FROM
	[dbo].[tblTrangThaiDonHang]
    WHERE 
	 ([MaTrangThaiDonHang] = @MaTrangThaiDonHang AND @MaTrangThaiDonHang is not null)
	OR ([MaLoaiTrangThaiDonHang] = @MaLoaiTrangThaiDonHang AND @MaLoaiTrangThaiDonHang is not null)
	OR ([TenLoaiTrangThaiDonHang] = @TenLoaiTrangThaiDonHang AND @TenLoaiTrangThaiDonHang is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhachHang_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tblKhachHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_Get_List

AS


				
				SELECT
					[MaKhachHang],
					[TenKhachHang],
					[Email],
					[SoDienThoai],
					[DiaChi],
					[Tuoi],
					[GioiTinh],
					[TinhTrangDa],
					[TayTrangToi],
					[RuaMat],
					[Toner],
					[Serum],
					[Kem],
					[SanPhamKhac],
					[LuuY],
					[ImageLink]
				FROM
					[dbo].[tblKhachHang]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhachHang_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tblKhachHang table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_GetPaged
(

	@WhereClause varchar (8000)  ,

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
				    [MaKhachHang] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MaKhachHang])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [MaKhachHang]'
				SET @SQL = @SQL + ' FROM [dbo].[tblKhachHang]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[MaKhachHang], O.[TenKhachHang], O.[Email], O.[SoDienThoai], O.[DiaChi], O.[Tuoi], O.[GioiTinh], O.[TinhTrangDa], O.[TayTrangToi], O.[RuaMat], O.[Toner], O.[Serum], O.[Kem], O.[SanPhamKhac], O.[LuuY], O.[ImageLink]
				FROM
				    [dbo].[tblKhachHang] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MaKhachHang] = PageIndex.[MaKhachHang]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tblKhachHang]'
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

	

-- Drop the dbo.tblKhachHang_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tblKhachHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_Insert
(

	@MaKhachHang int    OUTPUT,

	@TenKhachHang nvarchar (100)  ,

	@Email nvarchar (50)  ,

	@SoDienThoai nvarchar (50)  ,

	@DiaChi nvarchar (200)  ,

	@Tuoi int   ,

	@GioiTinh char (1)  ,

	@TinhTrangDa nvarchar (200)  ,

	@TayTrangToi bit   ,

	@RuaMat bit   ,

	@Toner bit   ,

	@Serum bit   ,

	@Kem bit   ,

	@SanPhamKhac bit   ,

	@Luuy nvarchar (200)  ,

	@ImageLink nvarchar (100)  
)
AS


				
				INSERT INTO [dbo].[tblKhachHang]
					(
					[TenKhachHang]
					,[Email]
					,[SoDienThoai]
					,[DiaChi]
					,[Tuoi]
					,[GioiTinh]
					,[TinhTrangDa]
					,[TayTrangToi]
					,[RuaMat]
					,[Toner]
					,[Serum]
					,[Kem]
					,[SanPhamKhac]
					,[LuuY]
					,[ImageLink]
					)
				VALUES
					(
					@TenKhachHang
					,@Email
					,@SoDienThoai
					,@DiaChi
					,@Tuoi
					,@GioiTinh
					,@TinhTrangDa
					,@TayTrangToi
					,@RuaMat
					,@Toner
					,@Serum
					,@Kem
					,@SanPhamKhac
					,@Luuy
					,@ImageLink
					)
				-- Get the identity value
				SET @MaKhachHang = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhachHang_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tblKhachHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_Update
(

	@MaKhachHang int   ,

	@TenKhachHang nvarchar (100)  ,

	@Email nvarchar (50)  ,

	@SoDienThoai nvarchar (50)  ,

	@DiaChi nvarchar (200)  ,

	@Tuoi int   ,

	@GioiTinh char (1)  ,

	@TinhTrangDa nvarchar (200)  ,

	@TayTrangToi bit   ,

	@RuaMat bit   ,

	@Toner bit   ,

	@Serum bit   ,

	@Kem bit   ,

	@SanPhamKhac bit   ,

	@Luuy nvarchar (200)  ,

	@ImageLink nvarchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tblKhachHang]
				SET
					[TenKhachHang] = @TenKhachHang
					,[Email] = @Email
					,[SoDienThoai] = @SoDienThoai
					,[DiaChi] = @DiaChi
					,[Tuoi] = @Tuoi
					,[GioiTinh] = @GioiTinh
					,[TinhTrangDa] = @TinhTrangDa
					,[TayTrangToi] = @TayTrangToi
					,[RuaMat] = @RuaMat
					,[Toner] = @Toner
					,[Serum] = @Serum
					,[Kem] = @Kem
					,[SanPhamKhac] = @SanPhamKhac
					,[LuuY] = @Luuy
					,[ImageLink] = @ImageLink
				WHERE
[MaKhachHang] = @MaKhachHang 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhachHang_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tblKhachHang table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_Delete
(

	@MaKhachHang int   
)
AS


				DELETE FROM [dbo].[tblKhachHang] WITH (ROWLOCK) 
				WHERE
					[MaKhachHang] = @MaKhachHang
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhachHang_GetByMaKhachHang procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_GetByMaKhachHang') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_GetByMaKhachHang
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tblKhachHang table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_GetByMaKhachHang
(

	@MaKhachHang int   
)
AS


				SELECT
					[MaKhachHang],
					[TenKhachHang],
					[Email],
					[SoDienThoai],
					[DiaChi],
					[Tuoi],
					[GioiTinh],
					[TinhTrangDa],
					[TayTrangToi],
					[RuaMat],
					[Toner],
					[Serum],
					[Kem],
					[SanPhamKhac],
					[LuuY],
					[ImageLink]
				FROM
					[dbo].[tblKhachHang]
				WHERE
					[MaKhachHang] = @MaKhachHang
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tblKhachHang_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tblKhachHang_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tblKhachHang_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tblKhachHang table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tblKhachHang_Find
(

	@SearchUsingOR bit   = null ,

	@MaKhachHang int   = null ,

	@TenKhachHang nvarchar (100)  = null ,

	@Email nvarchar (50)  = null ,

	@SoDienThoai nvarchar (50)  = null ,

	@DiaChi nvarchar (200)  = null ,

	@Tuoi int   = null ,

	@GioiTinh char (1)  = null ,

	@TinhTrangDa nvarchar (200)  = null ,

	@TayTrangToi bit   = null ,

	@RuaMat bit   = null ,

	@Toner bit   = null ,

	@Serum bit   = null ,

	@Kem bit   = null ,

	@SanPhamKhac bit   = null ,

	@Luuy nvarchar (200)  = null ,

	@ImageLink nvarchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaKhachHang]
	, [TenKhachHang]
	, [Email]
	, [SoDienThoai]
	, [DiaChi]
	, [Tuoi]
	, [GioiTinh]
	, [TinhTrangDa]
	, [TayTrangToi]
	, [RuaMat]
	, [Toner]
	, [Serum]
	, [Kem]
	, [SanPhamKhac]
	, [LuuY]
	, [ImageLink]
    FROM
	[dbo].[tblKhachHang]
    WHERE 
	 ([MaKhachHang] = @MaKhachHang OR @MaKhachHang IS NULL)
	AND ([TenKhachHang] = @TenKhachHang OR @TenKhachHang IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([SoDienThoai] = @SoDienThoai OR @SoDienThoai IS NULL)
	AND ([DiaChi] = @DiaChi OR @DiaChi IS NULL)
	AND ([Tuoi] = @Tuoi OR @Tuoi IS NULL)
	AND ([GioiTinh] = @GioiTinh OR @GioiTinh IS NULL)
	AND ([TinhTrangDa] = @TinhTrangDa OR @TinhTrangDa IS NULL)
	AND ([TayTrangToi] = @TayTrangToi OR @TayTrangToi IS NULL)
	AND ([RuaMat] = @RuaMat OR @RuaMat IS NULL)
	AND ([Toner] = @Toner OR @Toner IS NULL)
	AND ([Serum] = @Serum OR @Serum IS NULL)
	AND ([Kem] = @Kem OR @Kem IS NULL)
	AND ([SanPhamKhac] = @SanPhamKhac OR @SanPhamKhac IS NULL)
	AND ([LuuY] = @Luuy OR @Luuy IS NULL)
	AND ([ImageLink] = @ImageLink OR @ImageLink IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaKhachHang]
	, [TenKhachHang]
	, [Email]
	, [SoDienThoai]
	, [DiaChi]
	, [Tuoi]
	, [GioiTinh]
	, [TinhTrangDa]
	, [TayTrangToi]
	, [RuaMat]
	, [Toner]
	, [Serum]
	, [Kem]
	, [SanPhamKhac]
	, [LuuY]
	, [ImageLink]
    FROM
	[dbo].[tblKhachHang]
    WHERE 
	 ([MaKhachHang] = @MaKhachHang AND @MaKhachHang is not null)
	OR ([TenKhachHang] = @TenKhachHang AND @TenKhachHang is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([SoDienThoai] = @SoDienThoai AND @SoDienThoai is not null)
	OR ([DiaChi] = @DiaChi AND @DiaChi is not null)
	OR ([Tuoi] = @Tuoi AND @Tuoi is not null)
	OR ([GioiTinh] = @GioiTinh AND @GioiTinh is not null)
	OR ([TinhTrangDa] = @TinhTrangDa AND @TinhTrangDa is not null)
	OR ([TayTrangToi] = @TayTrangToi AND @TayTrangToi is not null)
	OR ([RuaMat] = @RuaMat AND @RuaMat is not null)
	OR ([Toner] = @Toner AND @Toner is not null)
	OR ([Serum] = @Serum AND @Serum is not null)
	OR ([Kem] = @Kem AND @Kem is not null)
	OR ([SanPhamKhac] = @SanPhamKhac AND @SanPhamKhac is not null)
	OR ([LuuY] = @Luuy AND @Luuy is not null)
	OR ([ImageLink] = @ImageLink AND @ImageLink is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

