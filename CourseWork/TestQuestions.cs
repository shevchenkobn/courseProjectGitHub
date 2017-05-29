using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public class TestQuestions
    {
        public enum IndexerParams
        { VariantsNumber }
        private int result;
        public int Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value < 0 ? 0 : value;
            }
        }
        public string this[int i]
        {
            get
            {
                CurrentTask = i;
                return taskNames[i];
            }
        }
        public int this[int i, IndexerParams param]
        {
            get
            {
                if (param == IndexerParams.VariantsNumber)
                    return variants[i].Length;
                else
                    return 0;
            }
        }
        public string this[int i, int j]
        {
            get
            {
                return variants[i][j];
            }
        }
        public int Count { get { return taskNames.Length; } }
        public int CurrentTask { get; private set; }
        string[][] variants { get; }
        string[] taskNames { get; }
        int[] rightVariants { get; }

        public void MarkAsDone(int variantNumber)
        {
            if (variantNumber == rightVariants[CurrentTask])
                Result++;
        }
        public TestQuestions(string[] testInFileNotation)
        {
            if (testInFileNotation.Length == 0)
                throw new ArgumentException("В тесте нет вопросов");
            CurrentTask = 0;
            variants = new string[testInFileNotation.Length][];
            rightVariants = new int[testInFileNotation.Length];
            taskNames = new string[testInFileNotation.Length];
            for (int i = 0; i < testInFileNotation.Length; i++)
            {
                string[] temp = testInFileNotation[i].Split(new string[] { ":::" }, StringSplitOptions.None);
                taskNames[i] = temp[0];
                variants[i] = temp[1].Split(new string[] { ";;;" }, StringSplitOptions.None);
                for (int j = 0; j < variants[i].Length; j++)
                {
                    if (variants[i][j][0] == '@' && variants[i][j][1] == '@')
                    {
                        variants[i][j] = variants[i][j].Substring(2);
                        rightVariants[i] = j;
                        break;
                    }
                }
            }
        }
    }
}
