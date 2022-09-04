(defvar n 3)
(loop
    (print n)
    (setq n (+ n 1))
    (when (> n 6) (return n))
)
(write-line ""))