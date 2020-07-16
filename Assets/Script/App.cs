using MyPlatformer.com;
using MyPlatformer.map;
using MyPlatformer.ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyPlatformer.app {
    public class App : MonoBehaviour
    {
        [SerializeField] private int _start_healph = 3;
        [SerializeField] private int _start_coins = 0;
        private int _m_health;
        private int _m_coins;
        private UpPanel upPanel;
        [SerializeField] private GameObject gameoverPanel=default;
        private MapGenerator map;
        public static bool isGameActive;
        private void Awake()
        {
            _m_coins = _start_coins;
            _m_health = _start_healph;
           
            ManagerPool.Instance.AddPool(PoolType.Box);
            ManagerPool.Instance.AddPool(PoolType.Trap);
            ManagerPool.Instance.AddPool(PoolType.Ui);
            upPanel = GameObject.Find("UpPanel").GetComponent<UpPanel>();
            if (upPanel)
            {
                upPanel.LifePanel.Create(_m_health);
            }
            upPanel.CoinsPanel.Add((_m_coins).ToString());

            map = GameObject.Find("Map").GetComponent<MapGenerator>();
            isGameActive = true;
        }
        private void Start()
        {
            gameoverPanel.SetActive(false);
            if (map)
                map.createMap();
        }
        public void resetLevel()
        {
            ManagerPool.Instance.Dispose();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public bool dellLife()
        {
            if (_m_health <= 0)
            {
                isGameActive = false;
                gameoverPanel.SetActive(true);
                return false;
            }
            _m_health--;
            upPanel.LifePanel.Dell();
            return true;
        }

        public void addLife()
        {
           
        }

        public void addCoins()
        {
            _m_coins++;
            upPanel.CoinsPanel.Add((_m_coins).ToString());
        }

        void OnGUI()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}