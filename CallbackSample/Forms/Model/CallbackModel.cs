using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace CallbackSample.Forms.Model
{

    /// <summary>Callbackサンプル.Model</summary>
    public class CallbackModel
    {

        /// <summary>一覧作成</summary>
        /// <param name="callback">コールバック関数</param>
        public void MakeList(Action<ObservableCollection<int>> callback, Action<int> callback2)
        {

            var values = new ObservableCollection<int>();
            var random = new Random(DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);

            for (var iLoop = 0; iLoop < random.Next(1000, 10000); iLoop++)
            {
                values.Add(random.Next());
            }

            for (var iLoop = 0; iLoop < 5; iLoop++)
            {

                callback2(5 - iLoop);
                Thread.Sleep(1000);

            }

            callback(values);

        }

    }

}
