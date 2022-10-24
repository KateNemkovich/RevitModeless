using Nuke.Common.IO;
using Nuke.Common.ProjectModel;

static class BuilderExtensions
{
    public static Project GetProject(this Solution solution, string projectName) =>
        solution.GetProject(projectName) ?? throw new NullReferenceException($"Cannon find project \"{projectName}\"");

    public static AbsolutePath GetBinDirectory(this Project project) => project.Directory / "bin";
}