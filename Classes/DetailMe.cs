namespace Classes
{
  class DetailMe
  {
    private string _name;
    public int Age;

    public DetailMe(string name, int age)
    {
      _name = name;
      Age = age;
    }

    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }
  }
}

