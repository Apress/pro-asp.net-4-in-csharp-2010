using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Hosting;


public class DBPathProvider : VirtualPathProvider {

    public static void AppInitialize() {
        HostingEnvironment.RegisterVirtualPathProvider(
            new DBPathProvider());
    }

    public override bool FileExists(string virtualPath) {
        string contents = this.GetFileFromDB(virtualPath);
        if (contents.Equals(string.Empty)) {
            return false;
        } else {
            return true;
        }
    }

    public override VirtualFile GetFile(string virtualPath) {
        string contents = this.GetFileFromDB(virtualPath);
        if (contents.Equals(string.Empty)) {
            return Previous.GetFile(virtualPath);
        } else {
            return new DBVirtualFile(virtualPath, contents);
        }
    }

    private string GetFileFromDB(string virtualPath) {
        string contents;
        string fileName = virtualPath.Substring(
                            virtualPath.IndexOf('/', 1) + 1);

        // Read the file from the database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"ASPNETCONTENTS\";Integrated Security=True";
        conn.Open();

        try {
            SqlCommand cmd = new SqlCommand(
                "SELECT FileContents FROM AspContent " +
                "WHERE FileName=@fn", conn);
            cmd.Parameters.AddWithValue("@fn", fileName);
            contents = cmd.ExecuteScalar() as string;
            if (contents == null)
                contents = string.Empty;
        } catch {
            contents = string.Empty;
        } finally {
            conn.Close();
        }

        return contents;
    }
}

public class DBVirtualFile : VirtualFile {

    private string _FileContent;

    public DBVirtualFile(string virtualPath, string fileContent)
        : base(virtualPath) {
        _FileContent = fileContent;
    }

    public override Stream Open() {
        Stream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);

        writer.Write(_FileContent);
        writer.Flush();
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}