# Test List

## Active
1. Take a set of packages and produce the paths for combination.
1. Hash the combined assess since this is before runtime we can hash the entire
combined content instead of just the file name and the file timestamp,
which we have done at runtime.  Hashing a large string is prohibitively slow
as a runtime operation.
1. Traverse multiple assemblies and find the right controllers. (Or none).
1. Serialize the paths for a controller so that we produce a single &lt;cache&gt;.
1. Serialize a cache so that we produce a single &lt;combined-resource&gt; with a
single &lt;cache&gt; element.
1. Deserialize a cache so that we produce a single &lt;combined-resource&gt; with a
single &lt;cache&gt; element.
1. Deserialize the paths for a controller so that we produce a single &lt;cache&gt;.
1. Write a tag provider that can use the Packaged up class and produce tags.


## Complete/Done

1. __Done__ Take a list of paths and combine the contents.
1. __Done__ Given a path and a path resolver produce the text of the file.
1. __Done__ Given a path and a path resolver produce the fully qualified path.



