# Filtering resources

  When fetching lists of resources it is possible in most cases to use OData
  filtering which allows to specify conditions to limit the data returned by the
  API.

  The syntax for filtering is adding `?$filter={condition}` at the
  end of the request URL. One could for example make a request asking for all
  users with the name Bob like this:
  `https://connect.digilean.tools/v1/Users?$filter=Name eq 'Bob'`
  
## Common filter expressions

### Filter by range

`?$filter=numberOfComments gt 10 and numberOfComments lt 20`

  This filter is used to return a list resources with numberOfComments greater
  than 10 and less than 20.

### Filtering by date

`?$filter=dueDate gt 2023-01-01T00:00:00Z`

  This filter used to return a list of recources with dueDates after the
  specified date.&nbsp;

Note that the date format has to be YYYY-MM-DDTHH:mm:ssZ.

### Filtering by equality

`?$filter=Name eq 'Bob'`

  This filter used to return a list of recources with Name that equals 'Bob'

### Combine

  It is also possible to *combine filters* by using the operators
  "and" / "or".

`?$filter=Name eq 'Bob' and isAdmin eq true`

  This filter is used to return a list of users with the name Bob and that are
  admins.

## Common operations

  Comparison Operators: eq (equal), ne (not equal), gt (greater than), ge
  (greater than or equal), lt (less than), le (less than or equal).

Logical Operators: and, or, not.

  More documentation can be found on
  <a href="https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/webservices/use-filter-expressions-in-odata-uris"
    target="_blank">
    Microsoft OData filter expressions
  </a>
