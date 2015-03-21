# cybernations_file_parser
C# parser for CyberNations Statistics files

This is a quick and dirty generic file parser that will use the header line of the input file to 
attempt to populate fields on the underlying model.  Note that the CyberNations Stats files do use column headers
with whitespace in them "Alliance ID", so we compress these by stripping whitespace.  Each model can optionally override
the CNColumnMapper() method to create it's own mappings between the CyberNations column name and the model.  In the models
included here, I've done that in a few places to support standardized C# UCamelCase naming conventions (e.g. AllianceID to
AllianceId).

The parser itself should not need to be modified if additional columns are added in the future to the CN Stats files, as
it looks for properties using Reflection.  However, your models will obviously have to change in order to support additional
fields of changes to column names.

Possible TODO:  Allow the suppression of columns that you don't care about in your models.

This library is NOT affiliated IN ANY WAY with the CyberNations game or its parent company.

CyberNations is a turn based strategy game that's been running for nearly ten years.  It maintains thousands of players with
an active forum and IRC community.

http://www.cybernations.com

Note that the actual data exported by the game is subject to a licensing agreement of Cybernations, which displayed
at the bottom of the stats download page:

http://www.cybernations.net/stats_downloads.asp

