using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace IdeallyConnected.Library.Tests.NaiveBayes
{
    
    public class NaiveBayesTests
    {
        [Fact]
        public void ModelDataEquivalentToFileData()
        {
            string datafile = "..\\..\\..\\Tests\\NaiveBayes\\breast_cancer.train";
            Model<BreastCancer> model = new Model<BreastCancer>();
            model.PopulateModel(datafile);
            // Check that model was created
            Assert.False(model == null);

            // Check that data was loaded
            Assert.False(model.Records.Count == 0);

            // Check that model data matches file data
            int record_i = 0;
            foreach(string frecord in File.ReadAllLines(datafile))
            {
                BreastCancer mrecord = model.Records[record_i++];
                string[] attributes = frecord.Split(' ');
                Assert.Equal(mrecord.ClassLabel, attributes[0]);
                for(int a_i = 1; a_i < attributes.Length; ++a_i)
                {
                    string attributeName = attributes[a_i].Split(':')[0];
                    string data = attributes[a_i].Split(':')[1];
                    // Check if attribute was stored
                    Assert.True(mrecord.Attribute.ContainsKey(attributeName), $"Attribute {attributeName} is not stored in model.");
                    // Check if attribute's data is correct
                    Assert.Equal(data, mrecord.Attribute[attributeName]);
                }
            }
        }

    }
}
