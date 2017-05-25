using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IdeallyConnected.Library
{
    /*
        This includes only the attribute and its data of a Model's classification.
    */
    public class ModelAttribute<TAttribute>
    {
        public string AttributeName { get; set; }
        public int Occurences { get; set; }

    }

    public interface IModel
    {
        object Create(string record);
    }

    /*
        The model encompasses all the classes used for classification.
    */
    public class Model<TModel> where TModel : class, IModel, new()
    {
        public Model()
        {
            Attributes = new HashSet<string>();
            Classes = new HashSet<string>();
            Records = new List<TModel>();
        }

        public HashSet<string> Attributes { get; set; }
        public HashSet<string> Classes { get; set; }
        public List<TModel> Records { get; set; }

        /*
            Load data from a file to populate the model.
        */
        public void PopulateModel(string datafile)
        {
            try
            {
                string[] records = File.ReadAllLines(datafile, Encoding.ASCII);
                foreach (string record in records)
                {
                    TModel model = Activator.CreateInstance(typeof(TModel), record) as TModel;
                    Records.Add(model);
                }
            }
            catch(FileNotFoundException e)
            {
                System.Diagnostics.Debug.WriteLine("File not opened.");
            }
        }
    }

    /*
        Used for categorical prediction (classification).
        The attributes of the data is stored; and statistics about the attributes
        and data class can be performed.
    */
    public class NaiveBayes
    {
        // Identifies how the classification model is trained.
        public enum LearningType { Supervised, Unsupervised }
        
        // the percentage of test set samples correctly classified
        public double AccuracyRate { get; set; }

        public NaiveBayes()
        {

        }        

    }
}
