using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MyLib.Tests")]
[assembly: InternalsVisibleTo("MyLib.DependencyInjectionExtensions")]

namespace MyLib.Infrastructure;

internal class Marker
{
}