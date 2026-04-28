public interface IState
{
    void Enter();   // Dipanggil saat masuk ke state
    void Update();  // Dipanggil setiap frame (Logic)
    void FixedUpdate(); // Untuk Fisika (Rigidbody)
    void Exit();    // Dipanggil sebelum pindah ke state lain
}