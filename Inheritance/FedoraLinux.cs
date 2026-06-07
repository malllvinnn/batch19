namespace Inheritance
{
  class FedoraLinux : LinuxKernel
  {

    public string OS;
    public override string Version => "7.0.11";

    public FedoraLinux(string os, string nameKernel)
    {
      OS = os;
      Name = nameKernel;
    }

    public void DetailOS()
    {
      Console.WriteLine($"APP DETAIL:\n- OS: {OS}\n- Kernel: {Name} {Version}");
    }
  }
}