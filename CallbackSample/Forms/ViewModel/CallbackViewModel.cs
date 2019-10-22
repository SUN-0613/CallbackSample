using AYam.Common.MVVM;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CallbackSample.Forms.ViewModel
{

    /// <summary>Callbackサンプル.ViewModel</summary>
    public class CallbackViewModel : ViewModelBase
    {

        #region Model

        /// <summary>Callbackサンプル.Model</summary>
        private Model.CallbackModel _Model;

        #endregion

        #region Property

        /// <summary>カウントダウン</summary>
        public int CountDown { get; set; }

        /// <summary>数値一覧</summary>
        public ObservableCollection<int> Values { get; set; }

        /// <summary>一覧作成コマンド</summary>
        public DelegateCommand MakeListCommand { get; }

        #endregion

        /// <summary>Callbackサンプル.ViewModel</summary>
        public CallbackViewModel()
        {

            _Model = new Model.CallbackModel();

            MakeListCommand = new DelegateCommand(
                () => 
                {

                    Task.Run(() => 
                    {
                        _Model.MakeList(Callback, CountDownCallback);
                    });

                }, 
                () => true);


        }

        /// <summary>コールバック関数</summary>
        /// <param name="values">数値一覧</param>
        public void Callback(ObservableCollection<int> values)
        {

            CountDownCallback(0);

            Values = values;
            CallPropertyChanged(nameof(Values));

        }

        /// <summary>コールバック関数２</summary>
        /// <param name="value">カウントダウン</param>
        public void CountDownCallback(int value)
        {
            CountDown = value;
            CallPropertyChanged(nameof(CountDown));
        }

    }

}
