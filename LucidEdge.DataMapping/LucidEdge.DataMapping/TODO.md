# TODO

Result-0/
	Row-0/
		ColumnName1 = Value (type)
		ColumnName2 = Value (type)
		ColumnName3 = Value (type)
		ColumnName4 = Value (type)
		ColumnName5 = Value (type)
	Row-1/
		ColumnName1 = Value (type)
		ColumnName2 = Value (type)
		ColumnName3 = Value (type)
		ColumnName4 = Value (type)
		ColumnName5 = Value (type)

This is a normal result shown as a heirarchy instead of a repetitive
array of keys and values.  The point is that we can see the simple heirarcy
of multiple items (rows) returned and the fields as tuples combined into
some aggregation that can then be given a meaningful name to better
express what the five columns together are trying to express.  That is to
say a better name than Result-0/Row-0. 

This is the simplest representation of a lot of data.  In some cases we need
relationships to other items represented in the data.  Here is an example
that illustrates ways this might be added to the data:

Result-0/
	Row-0/
		FirstName = Value (type)
		LastName = Value (type)
		DateOfBirth = Value (type)
		Parents = Parents/Row-0|Parents/Row-1 (type)
		Children = Children/Row-1 (type)
	Row-1
		FirstName = Value (type)
		LastName = Value (type)
		DateOfBirth = Value (type)
		Parents = Parents/Row-2|Parents/Row-3 (type)
		Children = Result-0/Row-2 (type)
	Row-2
		FirstName = Value (type)
		LastName = Value (type)
		DateOfBirth = Value (type)
		Parents = Result-0/Row-0|Result-0/Row-1 (type)
		Children = (type)
Parents/
	Row-0/
		FirstName = Value (type)
		LastName = Value (type)
	Row-1/
		FirstName = Value (type)
		LastName = Value (type)
	Row-2/
		FirstName = Value (type)
		LastName = Value (type)
	Row-3/
		FirstName = Value (type)
		LastName = Value (type)
		
What this illustration shows is one possible way to organize the data.
As it stands Result-0/ is a bit confusing because it doesn't carry any
information on what it contains.  Although Parents/ suggests a bit
more information about the contents, parents in computer science could
mean parent nodes in a tree data-structure not actual biological
parent/child relationships.

Another incidental consideration is that if all of Result-0 is filled
with people why do we need to break apart Parents from Children since
both parents and children are people.  The example does exactly this
when it come to children of Row-0 and Row-1.  What this means is that
the only difference between people provided in this data is the amount
of properties (or data points) returned.  In the case of parents, or
root parents, we recieve FirstName and LastName.  In the case, of
the parents of Row-2 we receive a bit more information.


