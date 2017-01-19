# Ideally Connected Utilities
The project was initially created with the intent to gather data, populate the database, and basically anything
to be done server side.  

## Web Crawlers
**Memo:** before crawling a webpage, look for */robots.txt* in a target domain's root folder. It should
contain some rules & guidelines made for human consumption. Stay out of trouble!

### Supporting Packages
Nuget packages *ScrapySharp* and *HtmlAgilityPack* are the tools that I will be using if I need to scrape online data
if there is no simple form available. At the moment, I have a JSON file containing an array of programming
languages, which I have successfully used to populate the dbo.ProgrammingLanguages table, and a text file
with a column of many Operating Systems that needs to be consumed.

*Last Updated 1/18/17* 