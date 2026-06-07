namespace Classes
{
  class Config
  {
    public readonly string AppName = "MalfinApp";
    public static int InstanceCount = 0;
    private static readonly string _tempPath = System.IO.Path.GetTempPath();

    // For Get private _tempPath (can't Set because readonly)
    public static string TempPath
    {
      get
      {
        return _tempPath;
      }
      // Can't Setter because field readonly ❌️
      // set
      // {
      //   _tempPath = value;
      // }
    }
  }
}